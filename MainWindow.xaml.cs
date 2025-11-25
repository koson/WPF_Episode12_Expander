using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF_Episode12_Expander
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowBasicExpander(object sender, RoutedEventArgs e)
        {
            var mainStack = CreateMainStack("Demo 1: Basic Expander");

            AddDescription(mainStack, "The simplest Expander - click the header to expand/collapse content:");

            // Basic expander
            var expander1 = new System.Windows.Controls.Expander
            {
                Header = "Click to Expand",
                Margin = new Thickness(0, 10, 0, 0)
            };
            var content1 = new TextBlock
            {
                Text = "This is the expanded content! Click the header again to collapse.",
                TextWrapping = TextWrapping.Wrap,
                Padding = new Thickness(10)
            };
            expander1.Content = content1;
            mainStack.Children.Add(expander1);

            // Expander with border
            var expander2 = new System.Windows.Controls.Expander
            {
                Header = "📦 Expander with Border",
                Margin = new Thickness(0, 10, 0, 0),
                BorderBrush = Brushes.Gray,
                BorderThickness = new Thickness(1)
            };
            var border = new Border
            {
                Background = Brushes.LightYellow,
                Padding = new Thickness(15),
                Margin = new Thickness(5)
            };
            border.Child = new TextBlock
            {
                Text = "Content with styled border and background.",
                TextWrapping = TextWrapping.Wrap
            };
            expander2.Content = border;
            mainStack.Children.Add(expander2);

            // Expander with complex content
            var expander3 = new System.Windows.Controls.Expander
            {
                Header = "🔽 Complex Content",
                Margin = new Thickness(0, 10, 0, 0)
            };
            var complexStack = new StackPanel { Padding = new Thickness(10) };
            complexStack.Children.Add(new TextBlock { Text = "📌 Item 1", Margin = new Thickness(0, 5) });
            complexStack.Children.Add(new TextBlock { Text = "📌 Item 2", Margin = new Thickness(0, 5) });
            complexStack.Children.Add(new TextBlock { Text = "📌 Item 3", Margin = new Thickness(0, 5) });
            complexStack.Children.Add(new Button { Content = "Click Me", Margin = new Thickness(0, 10, 0, 0) });
            expander3.Content = complexStack;
            mainStack.Children.Add(expander3);

            UpdateContent(mainStack);
        }

        private void ShowIsExpanded(object sender, RoutedEventArgs e)
        {
            var mainStack = CreateMainStack("Demo 2: IsExpanded Property");

            AddDescription(mainStack, "Control whether Expanders are open or closed by default:");

            // Collapsed by default
            var expander1 = new System.Windows.Controls.Expander
            {
                Header = "📁 Collapsed by Default (IsExpanded=False)",
                IsExpanded = false,
                Margin = new Thickness(0, 10, 0, 0)
            };
            expander1.Content = new TextBlock { Text = "This is hidden until you click the header.", Padding = new Thickness(10) };
            mainStack.Children.Add(expander1);

            // Expanded by default
            var expander2 = new System.Windows.Controls.Expander
            {
                Header = "📂 Expanded by Default (IsExpanded=True)",
                IsExpanded = true,
                Margin = new Thickness(0, 10, 0, 0)
            };
            expander2.Content = new TextBlock { Text = "This is visible immediately when the page loads.", Padding = new Thickness(10) };
            mainStack.Children.Add(expander2);

            // Programmatic control demo
            AddDescription(mainStack, "\nProgrammatic Control:");

            var controlStack = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 10, 0, 0) };
            var expandBtn = new Button { Content = "Expand All", Margin = new Thickness(5) };
            var collapseBtn = new Button { Content = "Collapse All", Margin = new Thickness(5) };
            controlStack.Children.Add(expandBtn);
            controlStack.Children.Add(collapseBtn);
            mainStack.Children.Add(controlStack);

            var expander3 = new System.Windows.Controls.Expander { Header = "Section 1", Margin = new Thickness(0, 10, 0, 0) };
            expander3.Content = new TextBlock { Text = "Content 1", Padding = new Thickness(10) };
            var expander4 = new System.Windows.Controls.Expander { Header = "Section 2", Margin = new Thickness(0, 10, 0, 0) };
            expander4.Content = new TextBlock { Text = "Content 2", Padding = new Thickness(10) };
            var expander5 = new System.Windows.Controls.Expander { Header = "Section 3", Margin = new Thickness(0, 10, 0, 0) };
            expander5.Content = new TextBlock { Text = "Content 3", Padding = new Thickness(10) };

            expandBtn.Click += (s, args) =>
            {
                expander3.IsExpanded = true;
                expander4.IsExpanded = true;
                expander5.IsExpanded = true;
            };

            collapseBtn.Click += (s, args) =>
            {
                expander3.IsExpanded = false;
                expander4.IsExpanded = false;
                expander5.IsExpanded = false;
            };

            mainStack.Children.Add(expander3);
            mainStack.Children.Add(expander4);
            mainStack.Children.Add(expander5);

            UpdateContent(mainStack);
        }

        private void ShowExpandDirection(object sender, RoutedEventArgs e)
        {
            var mainStack = CreateMainStack("Demo 3: ExpandDirection");

            AddDescription(mainStack, "Expander can expand in four directions:");

            var grid = new Grid { Margin = new Thickness(0, 20, 0, 0) };
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            // Down (default)
            var expanderDown = new System.Windows.Controls.Expander
            {
                Header = "Expand Down ▼",
                ExpandDirection = ExpandDirection.Down,
                Margin = new Thickness(5)
            };
            var downBorder = new Border { Background = Brushes.LightBlue, Padding = new Thickness(20) };
            downBorder.Child = new TextBlock { Text = "Content appears below", TextAlignment = TextAlignment.Center };
            expanderDown.Content = downBorder;
            Grid.SetRow(expanderDown, 0);
            Grid.SetColumn(expanderDown, 0);
            grid.Children.Add(expanderDown);

            // Up
            var expanderUp = new System.Windows.Controls.Expander
            {
                Header = "Expand Up ▲",
                ExpandDirection = ExpandDirection.Up,
                Margin = new Thickness(5)
            };
            var upBorder = new Border { Background = Brushes.LightGreen, Padding = new Thickness(20) };
            upBorder.Child = new TextBlock { Text = "Content appears above", TextAlignment = TextAlignment.Center };
            expanderUp.Content = upBorder;
            Grid.SetRow(expanderUp, 0);
            Grid.SetColumn(expanderUp, 1);
            grid.Children.Add(expanderUp);

            // Left
            var expanderLeft = new System.Windows.Controls.Expander
            {
                Header = "◀ Left",
                ExpandDirection = ExpandDirection.Left,
                Margin = new Thickness(5)
            };
            var leftBorder = new Border { Background = Brushes.LightCoral, Padding = new Thickness(20) };
            leftBorder.Child = new TextBlock { Text = "Left content" };
            expanderLeft.Content = leftBorder;
            Grid.SetRow(expanderLeft, 1);
            Grid.SetColumn(expanderLeft, 0);
            grid.Children.Add(expanderLeft);

            // Right
            var expanderRight = new System.Windows.Controls.Expander
            {
                Header = "Right ▶",
                ExpandDirection = ExpandDirection.Right,
                Margin = new Thickness(5)
            };
            var rightBorder = new Border { Background = Brushes.LightGoldenrodYellow, Padding = new Thickness(20) };
            rightBorder.Child = new TextBlock { Text = "Right content" };
            expanderRight.Content = rightBorder;
            Grid.SetRow(expanderRight, 1);
            Grid.SetColumn(expanderRight, 1);
            grid.Children.Add(expanderRight);

            mainStack.Children.Add(grid);
            UpdateContent(mainStack);
        }

        private void ShowFAQ(object sender, RoutedEventArgs e)
        {
            var mainStack = CreateMainStack("Demo 4: FAQ Section");

            AddDescription(mainStack, "Perfect for Frequently Asked Questions:");

            var faqs = new[]
            {
                new { Q = "❓ How do I reset my password?", A = "Click on 'Forgot Password' on the login page. Enter your email address, and we'll send you a reset link within 5 minutes." },
                new { Q = "❓ What payment methods do you accept?", A = "We accept all major credit cards (Visa, MasterCard, American Express), PayPal, and bank transfers." },
                new { Q = "❓ How can I contact support?", A = "You can reach our support team through:\n• Email: support@example.com\n• Phone: 1-800-123-4567\n• Live Chat: Available 24/7" },
                new { Q = "❓ Is there a free trial?", A = "Yes! We offer a 14-day free trial with full access to all features. No credit card required." },
                new { Q = "❓ Can I cancel my subscription?", A = "Yes, you can cancel anytime. Go to Account Settings → Subscription → Cancel. You'll have access until the end of your billing period." }
            };

            foreach (var faq in faqs)
            {
                var expander = new System.Windows.Controls.Expander
                {
                    Margin = new Thickness(0, 5, 0, 0)
                };

                var headerText = new TextBlock
                {
                    Text = faq.Q,
                    FontSize = 14,
                    FontWeight = FontWeights.Bold
                };
                expander.Header = headerText;

                var answerBorder = new Border
                {
                    Background = (Brush)new BrushConverter().ConvertFrom("#F8F9FA"),
                    Padding = new Thickness(15),
                    Margin = new Thickness(5)
                };
                answerBorder.Child = new TextBlock
                {
                    Text = faq.A,
                    TextWrapping = TextWrapping.Wrap
                };
                expander.Content = answerBorder;

                mainStack.Children.Add(expander);
            }

            UpdateContent(mainStack);
        }

        private void ShowSettings(object sender, RoutedEventArgs e)
        {
            var mainStack = CreateMainStack("Demo 5: Settings Panel");

            AddDescription(mainStack, "Organize settings into collapsible sections:");

            // Basic Settings
            var basicExpander = new System.Windows.Controls.Expander
            {
                Header = "Basic Settings",
                IsExpanded = true,
                Margin = new Thickness(0, 5, 0, 0)
            };
            var basicStack = new StackPanel { Margin = new Thickness(20, 10, 20, 10) };
            basicStack.Children.Add(new CheckBox { Content = "Enable notifications", Margin = new Thickness(0, 5) });
            basicStack.Children.Add(new CheckBox { Content = "Auto-save", Margin = new Thickness(0, 5), IsChecked = true });
            basicStack.Children.Add(new CheckBox { Content = "Dark mode", Margin = new Thickness(0, 5) });
            basicExpander.Content = basicStack;
            mainStack.Children.Add(basicExpander);

            // Advanced Settings
            var advancedExpander = new System.Windows.Controls.Expander
            {
                Header = "Advanced Settings",
                Margin = new Thickness(0, 5, 0, 0)
            };
            var advancedStack = new StackPanel { Margin = new Thickness(20, 10, 20, 10) };
            advancedStack.Children.Add(new CheckBox { Content = "Developer mode", Margin = new Thickness(0, 5) });
            advancedStack.Children.Add(new CheckBox { Content = "Debug logging", Margin = new Thickness(0, 5) });
            advancedStack.Children.Add(new CheckBox { Content = "Performance monitoring", Margin = new Thickness(0, 5) });
            advancedStack.Children.Add(new CheckBox { Content = "Memory profiling", Margin = new Thickness(0, 5) });
            advancedExpander.Content = advancedStack;
            mainStack.Children.Add(advancedExpander);

            // Network Settings
            var networkExpander = new System.Windows.Controls.Expander
            {
                Header = "Network Settings",
                Margin = new Thickness(0, 5, 0, 0)
            };
            var networkStack = new StackPanel { Margin = new Thickness(20, 10, 20, 10) };
            networkStack.Children.Add(new CheckBox { Content = "Use proxy", Margin = new Thickness(0, 5) });
            networkStack.Children.Add(new CheckBox { Content = "Cache enabled", Margin = new Thickness(0, 5), IsChecked = true });
            networkStack.Children.Add(new CheckBox { Content = "Offline mode", Margin = new Thickness(0, 5) });
            networkExpander.Content = networkStack;
            mainStack.Children.Add(networkExpander);

            // Appearance Settings
            var appearanceExpander = new System.Windows.Controls.Expander
            {
                Header = "Appearance Settings",
                Margin = new Thickness(0, 5, 0, 0)
            };
            var appearanceStack = new StackPanel { Margin = new Thickness(20, 10, 20, 10) };
            appearanceStack.Children.Add(new CheckBox { Content = "Show toolbar", Margin = new Thickness(0, 5), IsChecked = true });
            appearanceStack.Children.Add(new CheckBox { Content = "Show status bar", Margin = new Thickness(0, 5), IsChecked = true });
            appearanceStack.Children.Add(new CheckBox { Content = "Compact view", Margin = new Thickness(0, 5) });
            appearanceExpander.Content = appearanceStack;
            mainStack.Children.Add(appearanceExpander);

            UpdateContent(mainStack);
        }

        private void ShowProductDetails(object sender, RoutedEventArgs e)
        {
            var mainStack = CreateMainStack("Demo 6: Product Details");

            AddDescription(mainStack, "Product page with collapsible details:");

            // Product Title
            mainStack.Children.Add(new TextBlock { Text = "Premium Wireless Headphones", FontSize = 20, FontWeight = FontWeights.Bold, Margin = new Thickness(0, 10, 0, 10) });
            mainStack.Children.Add(new TextBlock { Text = "$299.99", FontSize = 28, Foreground = Brushes.Green, FontWeight = FontWeights.Bold, Margin = new Thickness(0, 0, 0, 20) });

            // Description
            var descExpander = new System.Windows.Controls.Expander
            {
                Header = "📝 Description",
                IsExpanded = true,
                Margin = new Thickness(0, 5, 0, 0),
                Background = Brushes.White,
                BorderBrush = Brushes.LightGray,
                BorderThickness = new Thickness(1)
            };
            var descBorder = new Border { Padding = new Thickness(15), Background = (Brush)new BrushConverter().ConvertFrom("#FAFAFA") };
            descBorder.Child = new TextBlock { Text = "Experience premium sound quality with our flagship wireless headphones. Featuring active noise cancellation, 30-hour battery life, and premium comfort materials.", TextWrapping = TextWrapping.Wrap };
            descExpander.Content = descBorder;
            mainStack.Children.Add(descExpander);

            // Specifications
            var specExpander = new System.Windows.Controls.Expander
            {
                Header = "🔧 Technical Specifications",
                Margin = new Thickness(0, 5, 0, 0),
                Background = Brushes.White,
                BorderBrush = Brushes.LightGray,
                BorderThickness = new Thickness(1)
            };
            var specBorder = new Border { Padding = new Thickness(15), Background = (Brush)new BrushConverter().ConvertFrom("#FAFAFA") };
            var specStack = new StackPanel();
            specStack.Children.Add(new TextBlock { Text = "• Driver: 40mm Dynamic", Margin = new Thickness(0, 3) });
            specStack.Children.Add(new TextBlock { Text = "• Frequency: 20Hz - 20kHz", Margin = new Thickness(0, 3) });
            specStack.Children.Add(new TextBlock { Text = "• Battery: 30 hours playback", Margin = new Thickness(0, 3) });
            specStack.Children.Add(new TextBlock { Text = "• Connectivity: Bluetooth 5.0", Margin = new Thickness(0, 3) });
            specBorder.Child = specStack;
            specExpander.Content = specBorder;
            mainStack.Children.Add(specExpander);

            // Shipping
            var shippingExpander = new System.Windows.Controls.Expander
            {
                Header = "🚚 Shipping & Returns",
                Margin = new Thickness(0, 5, 0, 0),
                Background = Brushes.White,
                BorderBrush = Brushes.LightGray,
                BorderThickness = new Thickness(1)
            };
            var shippingBorder = new Border { Padding = new Thickness(15), Background = (Brush)new BrushConverter().ConvertFrom("#FAFAFA") };
            shippingBorder.Child = new TextBlock { Text = "Free standard shipping on orders over $50. 30-day money-back guarantee.", TextWrapping = TextWrapping.Wrap };
            shippingExpander.Content = shippingBorder;
            mainStack.Children.Add(shippingExpander);

            UpdateContent(mainStack);
        }

        private void ShowNavigation(object sender, RoutedEventArgs e)
        {
            var mainStack = CreateMainStack("Demo 7: Navigation Menu");

            AddDescription(mainStack, "Accordion-style navigation menu:");

            var menuPanel = new StackPanel { Background = (Brush)new BrushConverter().ConvertFrom("#2C3E50"), Width = 250, Margin = new Thickness(0, 10, 0, 0) };

            // Dashboard
            var dashboardExpander = new System.Windows.Controls.Expander
            {
                Background = (Brush)new BrushConverter().ConvertFrom("#34495E"),
                Foreground = Brushes.White,
                Margin = new Thickness(0, 1, 0, 0),
                IsExpanded = true,
                Header = new TextBlock { Text = "📊 Dashboard", FontWeight = FontWeights.Bold }
            };
            var dashboardStack = new StackPanel { Background = (Brush)new BrushConverter().ConvertFrom("#2C3E50") };
            dashboardStack.Children.Add(CreateMenuButton("Overview"));
            dashboardStack.Children.Add(CreateMenuButton("Analytics"));
            dashboardStack.Children.Add(CreateMenuButton("Reports"));
            dashboardExpander.Content = dashboardStack;
            menuPanel.Children.Add(dashboardExpander);

            // Products
            var productsExpander = new System.Windows.Controls.Expander
            {
                Background = (Brush)new BrushConverter().ConvertFrom("#34495E"),
                Foreground = Brushes.White,
                Margin = new Thickness(0, 1, 0, 0),
                Header = new TextBlock { Text = "📦 Products", FontWeight = FontWeights.Bold }
            };
            var productsStack = new StackPanel { Background = (Brush)new BrushConverter().ConvertFrom("#2C3E50") };
            productsStack.Children.Add(CreateMenuButton("All Products"));
            productsStack.Children.Add(CreateMenuButton("Add New"));
            productsStack.Children.Add(CreateMenuButton("Categories"));
            productsExpander.Content = productsStack;
            menuPanel.Children.Add(productsExpander);

            // Settings
            var settingsExpander = new System.Windows.Controls.Expander
            {
                Background = (Brush)new BrushConverter().ConvertFrom("#34495E"),
                Foreground = Brushes.White,
                Margin = new Thickness(0, 1, 0, 0),
                Header = new TextBlock { Text = "⚙️ Settings", FontWeight = FontWeights.Bold }
            };
            var settingsStack = new StackPanel { Background = (Brush)new BrushConverter().ConvertFrom("#2C3E50") };
            settingsStack.Children.Add(CreateMenuButton("General"));
            settingsStack.Children.Add(CreateMenuButton("Security"));
            settingsStack.Children.Add(CreateMenuButton("Notifications"));
            settingsExpander.Content = settingsStack;
            menuPanel.Children.Add(settingsExpander);

            mainStack.Children.Add(menuPanel);
            UpdateContent(mainStack);
        }

        private void ShowStyledExpanders(object sender, RoutedEventArgs e)
        {
            var mainStack = CreateMainStack("Demo 8: Styled Expanders");

            AddDescription(mainStack, "Expanders with custom styling:");

            // Success expander
            var successExpander = new System.Windows.Controls.Expander
            {
                Header = "✓ Success Message",
                Background = (Brush)new BrushConverter().ConvertFrom("#D4EDDA"),
                BorderBrush = (Brush)new BrushConverter().ConvertFrom("#C3E6CB"),
                BorderThickness = new Thickness(1),
                Margin = new Thickness(0, 10, 0, 0),
                Padding = new Thickness(5)
            };
            var successBorder = new Border { Background = Brushes.White, Padding = new Thickness(15), Margin = new Thickness(5) };
            var successStack = new StackPanel();
            successStack.Children.Add(new TextBlock { Text = "Operation completed successfully!", Foreground = (Brush)new BrushConverter().ConvertFrom("#155724"), FontWeight = FontWeights.Bold });
            successStack.Children.Add(new TextBlock { Text = "All items were processed.", Margin = new Thickness(0, 5, 0, 0) });
            successBorder.Child = successStack;
            successExpander.Content = successBorder;
            mainStack.Children.Add(successExpander);

            // Error expander
            var errorExpander = new System.Windows.Controls.Expander
            {
                Header = "✗ Error Details",
                Background = (Brush)new BrushConverter().ConvertFrom("#F8D7DA"),
                BorderBrush = (Brush)new BrushConverter().ConvertFrom("#F5C6CB"),
                BorderThickness = new Thickness(1),
                Margin = new Thickness(0, 10, 0, 0),
                Padding = new Thickness(5)
            };
            var errorBorder = new Border { Background = Brushes.White, Padding = new Thickness(15), Margin = new Thickness(5) };
            var errorStack = new StackPanel();
            errorStack.Children.Add(new TextBlock { Text = "An error occurred", Foreground = (Brush)new BrushConverter().ConvertFrom("#721C24"), FontWeight = FontWeights.Bold });
            errorStack.Children.Add(new TextBlock { Text = "Check the logs for details.", Margin = new Thickness(0, 5, 0, 0) });
            errorBorder.Child = errorStack;
            errorExpander.Content = errorBorder;
            mainStack.Children.Add(errorExpander);

            // Info expander
            var infoExpander = new System.Windows.Controls.Expander
            {
                Header = "ℹ Information",
                Background = (Brush)new BrushConverter().ConvertFrom("#D1ECF1"),
                BorderBrush = (Brush)new BrushConverter().ConvertFrom("#BEE5EB"),
                BorderThickness = new Thickness(1),
                Margin = new Thickness(0, 10, 0, 0),
                Padding = new Thickness(5)
            };
            var infoBorder = new Border { Background = Brushes.White, Padding = new Thickness(15), Margin = new Thickness(5) };
            infoBorder.Child = new TextBlock { Text = "This is an informational message with additional details.", TextWrapping = TextWrapping.Wrap };
            infoExpander.Content = infoBorder;
            mainStack.Children.Add(infoExpander);

            UpdateContent(mainStack);
        }

        private void ShowAdvancedFilter(object sender, RoutedEventArgs e)
        {
            var mainStack = CreateMainStack("Demo 9: Advanced Filter Panel");

            AddDescription(mainStack, "Complex filtering interface with nested expanders:");

            var filterExpander = new System.Windows.Controls.Expander
            {
                Header = "🔍 Advanced Filters",
                IsExpanded = true,
                Margin = new Thickness(0, 10, 0, 0),
                Padding = new Thickness(10),
                Background = Brushes.WhiteSmoke
            };

            var filterStack = new StackPanel { Margin = new Thickness(10) };

            // Date Range
            var dateExpander = new System.Windows.Controls.Expander
            {
                Header = "📅 Date Range",
                Margin = new Thickness(0, 5, 0, 0),
                IsExpanded = true
            };
            var dateStack = new StackPanel { Margin = new Thickness(20, 10, 20, 10) };
            var fromStack = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5) };
            fromStack.Children.Add(new TextBlock { Text = "From:", Width = 60, VerticalAlignment = VerticalAlignment.Center });
            fromStack.Children.Add(new DatePicker { Width = 150 });
            dateStack.Children.Add(fromStack);
            var toStack = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5) };
            toStack.Children.Add(new TextBlock { Text = "To:", Width = 60, VerticalAlignment = VerticalAlignment.Center });
            toStack.Children.Add(new DatePicker { Width = 150 });
            dateStack.Children.Add(toStack);
            dateExpander.Content = dateStack;
            filterStack.Children.Add(dateExpander);

            // Categories
            var categoryExpander = new System.Windows.Controls.Expander
            {
                Header = "📂 Categories",
                Margin = new Thickness(0, 5, 0, 0)
            };
            var categoryStack = new StackPanel { Margin = new Thickness(20, 10, 20, 10) };
            categoryStack.Children.Add(new CheckBox { Content = "Electronics", Margin = new Thickness(0, 3) });
            categoryStack.Children.Add(new CheckBox { Content = "Clothing", Margin = new Thickness(0, 3) });
            categoryStack.Children.Add(new CheckBox { Content = "Books", Margin = new Thickness(0, 3) });
            categoryStack.Children.Add(new CheckBox { Content = "Home & Garden", Margin = new Thickness(0, 3) });
            categoryExpander.Content = categoryStack;
            filterStack.Children.Add(categoryExpander);

            // Price Range
            var priceExpander = new System.Windows.Controls.Expander
            {
                Header = "💰 Price Range",
                Margin = new Thickness(0, 5, 0, 0)
            };
            var priceStack = new StackPanel { Margin = new Thickness(20, 10, 20, 10) };
            var minStack = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5) };
            minStack.Children.Add(new TextBlock { Text = "Min:", Width = 60, VerticalAlignment = VerticalAlignment.Center });
            minStack.Children.Add(new TextBox { Width = 100, Text = "0" });
            priceStack.Children.Add(minStack);
            var maxStack = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5) };
            maxStack.Children.Add(new TextBlock { Text = "Max:", Width = 60, VerticalAlignment = VerticalAlignment.Center });
            maxStack.Children.Add(new TextBox { Width = 100, Text = "1000" });
            priceStack.Children.Add(maxStack);
            priceExpander.Content = priceStack;
            filterStack.Children.Add(priceExpander);

            // Apply button
            filterStack.Children.Add(new Button
            {
                Content = "Apply Filters",
                Margin = new Thickness(0, 15, 0, 5),
                Padding = new Thickness(10, 5),
                Background = Brushes.Navy,
                Foreground = Brushes.White
            });

            filterExpander.Content = filterStack;
            mainStack.Children.Add(filterExpander);

            UpdateContent(mainStack);
        }

        // Helper methods
        private StackPanel CreateMainStack(string title)
        {
            var stack = new StackPanel();
            stack.Children.Add(new TextBlock
            {
                Text = title,
                FontSize = 24,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 0, 0, 10)
            });
            return stack;
        }

        private void AddDescription(StackPanel parent, string text)
        {
            parent.Children.Add(new TextBlock
            {
                Text = text,
                FontSize = 14,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(0, 0, 0, 10)
            });
        }

        private Button CreateMenuButton(string text)
        {
            return new Button
            {
                Content = text,
                Background = Brushes.Transparent,
                Foreground = Brushes.White,
                BorderThickness = new Thickness(0),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                HorizontalContentAlignment = HorizontalAlignment.Left,
                Padding = new Thickness(20, 8, 20, 8),
                Cursor = System.Windows.Input.Cursors.Hand
            };
        }

        private void UpdateContent(StackPanel content)
        {
            var container = new Border
            {
                Background = Brushes.White,
                Margin = new Thickness(20),
                Padding = new Thickness(30),
                CornerRadius = new CornerRadius(10)
            };
            container.Child = content;
            ContentPanel.Content = container;
        }
    }
}
