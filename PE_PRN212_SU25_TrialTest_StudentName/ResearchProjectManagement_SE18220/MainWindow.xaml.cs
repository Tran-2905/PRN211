using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL.Service;
using DAL.Entity;
using DAL.Repository;

namespace ResearchProjectManagement_SE18220
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ResearchProjectService researchProjectService;
        private readonly ResearcherService researcherService;
        public int? Role { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            researchProjectService = new ResearchProjectService();
            researcherService = new ResearcherService();
            //userAccountService = new UserAccountService();
            LoadResearchProject();
            LoadResearcher();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Role == 1)
            {
                // Admin role, show all functionalities
                btnAdd.Visibility = Visibility.Visible;
                btnEdit.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
            }
            else if (Role == 2)
            {
                // Researcher role, show limited functionalities
                btnAdd.Visibility = Visibility.Visible;
                btnEdit.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Collapsed; // Hide delete button
            }
            else if (Role == 3)
            {
                // Viewer role, show only view functionality
                btnAdd.Visibility = Visibility.Collapsed;
                btnEdit.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed; // Hide all buttons

            }
        }
        private void LoadResearchProject()
        {
            dgResearchList.ItemsSource = researchProjectService.GetAllProjects();
        }
        private void LoadResearcher()
        {
            cbLeadResearcher.ItemsSource = this.researcherService.GetAllResearchers();
            cbLeadResearcher.DisplayMemberPath = "FullName";
            cbLeadResearcher.SelectedValuePath = "ResearcherId";
        }
       
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
               dgResearchList.ItemsSource = researchProjectService.GetProjectByTitleOrField(txtSearch.Text);
            } else
            {
                LoadResearchProject();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // Create a new ResearchProject object and populate it with data from the form
            if (string.IsNullOrEmpty(txProjectTitle.Text) ||
                string.IsNullOrEmpty(txResearchField.Text) ||
                string.IsNullOrEmpty(txStartDate.Text) ||
                string.IsNullOrEmpty(txEndDate.Text) ||
                string.IsNullOrEmpty(txBudget.Text) ||
                cbLeadResearcher.SelectedValue == null)
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (txProjectTitle.Text.Length > 100)
            {
                MessageBox.Show("Project title cannot exceed 100 characters.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (txProjectTitle.Text.Length <5)
            {
                MessageBox.Show("Research field cannot lesser than 5 characters.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!Regex.IsMatch(txProjectTitle.Text, @"^[A-Z0-9]"))
            {
                MessageBox.Show("Project title must start with a capital letter or digit.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Regex.IsMatch(txProjectTitle.Text, @"[^a-zA-Z0-9\s]"))
            {
                MessageBox.Show("Project title cannot contain special characters.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            ResearchProject newProject = new ResearchProject
            {
                ProjectTitle = txProjectTitle.Text,
                ResearchField = txResearchField.Text,
                StartDate = DateOnly.Parse(txStartDate.Text),
                EndDate = DateOnly.Parse(txEndDate.Text),
                Budget = decimal.Parse(txBudget.Text),
                LeadResearcherId = (int)cbLeadResearcher.SelectedValue
            };
            if (newProject.StartDate > newProject.EndDate)
            {
                MessageBox.Show("Start date cannot be later than end date.", "Invalid Date Range", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // Call the service to add the project
            researchProjectService.AddProject(newProject);
            // Refresh the list after adding
            LoadResearchProject();
            // Optionally, clear the form fields
        

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txProjectTitle.Text) ||
                string.IsNullOrEmpty(txResearchField.Text) ||
                string.IsNullOrEmpty(txStartDate.Text) ||
                string.IsNullOrEmpty(txEndDate.Text) ||
                string.IsNullOrEmpty(txBudget.Text) ||
                cbLeadResearcher.SelectedValue == null)
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (txProjectTitle.Text.Length > 100)
            {
                MessageBox.Show("Project title cannot exceed 100 characters.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (txProjectTitle.Text.Length < 5)
            {
                MessageBox.Show("Research field cannot lesser than 5 characters.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!Regex.IsMatch(txProjectTitle.Text, @"^[A-Z0-9]"))
            {
                MessageBox.Show("Project title must start with a capital letter or digit.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Regex.IsMatch(txProjectTitle.Text, @"[^a-zA-Z0-9\s]"))
            {
                MessageBox.Show("Project title cannot contain special characters.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            ResearchProject newProject = new ResearchProject
            {
                ProjectId = ((ResearchProject)dgResearchList.SelectedItem).ProjectId, // Assuming the selected item is a ResearchProject
                ProjectTitle = txProjectTitle.Text,
                ResearchField = txResearchField.Text,
                StartDate = DateOnly.Parse(txStartDate.Text),
                EndDate = DateOnly.Parse(txEndDate.Text),
                Budget = decimal.Parse(txBudget.Text),
                LeadResearcherId = (int)cbLeadResearcher.SelectedValue
            };
            if (newProject.StartDate > newProject.EndDate)
            {
                MessageBox.Show("Start date cannot be later than end date.", "Invalid Date Range", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // Call the service to add the project
            researchProjectService.UpdateProject(newProject);
            Console.WriteLine("here");
            // Refresh the list after adding
            LoadResearchProject();
          
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dgResearchList.SelectedItem is ResearchProject selectedProject)
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the project '{selectedProject.ProjectTitle}'?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    // Call the service to delete the project
                    this.researchProjectService.DeleteProject(selectedProject.ProjectId);
                    // researchProjectService.DeleteProject(selectedProject.ProjectId);
                    LoadResearchProject(); // Refresh the list after deletion
                }
            }
            else
            {
                MessageBox.Show("Please select a project to delete.", "No Project Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void dgResearchList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgResearchList.SelectedItem is ResearchProject selectedProject)
            {
                txProjectTitle.Text = selectedProject.ProjectTitle;
                txResearchField.Text = selectedProject.ResearchField;
                txStartDate.Text = selectedProject.StartDate.ToString();
                txEndDate.Text = selectedProject.EndDate.ToString();
                txBudget.Text = selectedProject.Budget.ToString();
                cbLeadResearcher.SelectedValue = selectedProject.LeadResearcherId;
            }
        }
    }
}