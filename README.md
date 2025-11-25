# 🎓 Episode 12: Expander - Complete Guide

> **Problem to Solve**: How to manage space-limited UIs by showing/hiding optional content while keeping important information visible?

[![.NET](https://img.shields.io/badge/.NET-9.0-blue.svg)](https://dotnet.microsoft.com/download)
[![WPF](https://img.shields.io/badge/WPF-Controls-purple.svg)](#)
[![Episode](https://img.shields.io/badge/Episode-12-green.svg)](#)
[![Duration](https://img.shields.io/badge/Duration-32min-orange.svg)](#)

---

## 🎯 Learning Objectives

By the end of this episode, you will be able to:

- ✅ Understand when content should be collapsible
- ✅ Use Expander to create expandable/collapsible sections
- ✅ Control expansion state with IsExpanded
- ✅ Set expansion direction (Down, Up, Left, Right)
- ✅ Build FAQ sections, settings panels, and accordions
- ✅ Style Expander headers and content

---

## 📖 Table of Contents

1. [The Problems We'll Solve](#the-problems-well-solve)
2. [Problem: Too Much Content for Limited Space](#problem-too-much-content-for-limited-space)
3. [Expander Solution](#expander-solution)
4. [IsExpanded Property](#isexpanded-property)
5. [ExpandDirection Property](#expanddirection-property)
6. [Styling Expander](#styling-expander)
7. [Real-World Examples](#real-world-examples)
8. [Advanced Techniques](#advanced-techniques)
9. [Best Practices](#best-practices)
10. [Common Problems & Solutions](#common-problems--solutions)
11. [Summary](#summary)

---

## 🤔 The Problems We'll Solve

### Today's Journey:

We'll see how **displaying all content at once** causes problems and solve it with Expander:

1. **Problem**: Limited screen space, too much content
2. **Limitation**: Users overwhelmed by information
3. **Solution**: Collapsible sections with Expander!
4. **Real-World**: FAQs, settings, advanced options, navigation
5. **Best Practices**: When and how to use Expander

Let's start! 🚀

---

## ❌ Problem: Too Much Content for Limited Space

### Scenario: Settings Panel with Many Options

You want to create a **settings panel**, but showing all options at once is overwhelming:

### Attempt 1: All Content Visible

```xml
<StackPanel Margin="20">
    <!-- Basic Settings -->
    <TextBlock Text="Basic Settings" FontSize="16" FontWeight="Bold" 
               Margin="0,0,0,10"/>
    <CheckBox Content="Enable notifications" Margin="0,5"/>
    <CheckBox Content="Auto-save" Margin="0,5"/>
    <CheckBox Content="Dark mode" Margin="0,5"/>
    
    <!-- Advanced Settings -->
    <TextBlock Text="Advanced Settings" FontSize="16" FontWeight="Bold" 
               Margin="0,20,0,10"/>
    <CheckBox Content="Developer mode" Margin="0,5"/>
    <CheckBox Content="Debug logging" Margin="0,5"/>
    <CheckBox Content="Performance monitoring" Margin="0,5"/>
    <CheckBox Content="Memory profiling" Margin="0,5"/>
    
    <!-- Network Settings -->
    <TextBlock Text="Network Settings" FontSize="16" FontWeight="Bold" 
               Margin="0,20,0,10"/>
    <CheckBox Content="Use proxy" Margin="0,5"/>
    <CheckBox Content="Cache enabled" Margin="0,5"/>
    <CheckBox Content="Offline mode" Margin="0,5"/>
    
    <!-- Appearance Settings -->
    <TextBlock Text="Appearance Settings" FontSize="16" FontWeight="Bold" 
               Margin="0,20,0,10"/>
    <CheckBox Content="Show toolbar" Margin="0,5"/>
    <CheckBox Content="Show status bar" Margin="0,5"/>
    <CheckBox Content="Compact view" Margin="0,5"/>
    
    <!-- ... more sections ... -->
</StackPanel>
```

**Problems:**

❌ Takes too much vertical space  
❌ Users must scroll extensively  
❌ Hard to find specific settings  
❌ Overwhelming amount of visible options  
❌ No visual hierarchy

### Attempt 2: Using TabControl

```xml
<TabControl>
    <TabItem Header="Basic">
        <!-- Basic settings -->
    </TabItem>
    <TabItem Header="Advanced">
        <!-- Advanced settings -->
    </TabItem>
    <TabItem Header="Network">
        <!-- Network settings -->
    </TabItem>
    <TabItem Header="Appearance">
        <!-- Appearance settings -->
    </TabItem>
</TabControl>
```

**Still Problems:**

❌ Can only see one category at a time  
❌ Requires clicking tabs to compare settings  
❌ Not ideal for hierarchical content  
❌ Takes horizontal space for tabs

**We need**: A way to show/hide sections while keeping all categories visible! 💡

---

## ✅ Expander Solution

### What is Expander?

**Expander** is a control that:
- **Has a header** that's always visible
- **Contains content** that can be shown or hidden
- **Saves space** by collapsing when not needed
- **Maintains context** - all headers remain visible
- **Easy to use** - single click to expand/collapse

Think of it as an **accordion drawer** - you can open what you need! 🗂️

### The Fix: Using Expander

```xml
<StackPanel Margin="20">
    <!-- Basic Settings - Always visible header -->
    <Expander Header="Basic Settings" IsExpanded="True" Margin="0,5">
        <StackPanel Margin="20,10">
            <CheckBox Content="Enable notifications" Margin="0,5"/>
            <CheckBox Content="Auto-save" Margin="0,5"/>
            <CheckBox Content="Dark mode" Margin="0,5"/>
        </StackPanel>
    </Expander>
    
    <!-- Advanced Settings - Collapsed by default -->
    <Expander Header="Advanced Settings" Margin="0,5">
        <StackPanel Margin="20,10">
            <CheckBox Content="Developer mode" Margin="0,5"/>
            <CheckBox Content="Debug logging" Margin="0,5"/>
            <CheckBox Content="Performance monitoring" Margin="0,5"/>
            <CheckBox Content="Memory profiling" Margin="0,5"/>
        </StackPanel>
    </Expander>
    
    <!-- Network Settings -->
    <Expander Header="Network Settings" Margin="0,5">
        <StackPanel Margin="20,10">
            <CheckBox Content="Use proxy" Margin="0,5"/>
            <CheckBox Content="Cache enabled" Margin="0,5"/>
            <CheckBox Content="Offline mode" Margin="0,5"/>
        </StackPanel>
    </Expander>
    
    <!-- Appearance Settings -->
    <Expander Header="Appearance Settings" Margin="0,5">
        <StackPanel Margin="20,10">
            <CheckBox Content="Show toolbar" Margin="0,5"/>
            <CheckBox Content="Show status bar" Margin="0,5"/>
            <CheckBox Content="Compact view" Margin="0,5"/>
        </StackPanel>
    </Expander>
</StackPanel>
```

**Result:**

✅ All section headers visible at once  
✅ Content hidden until needed  
✅ Minimal scrolling required  
✅ Easy to find and access settings  
✅ Clear visual hierarchy  
✅ User controls what they see

---

## 🔧 IsExpanded Property

### Controlling Expansion State

The **IsExpanded** property determines whether content is visible:

### Default Behavior (IsExpanded="False")

```xml
<Expander Header="Click to Expand">
    <TextBlock Text="This content is hidden by default" Padding="10"/>
</Expander>
```

**Behavior:**
- ❌ Content hidden on load
- 👆 Click header to expand
- 👆 Click again to collapse

---

### Expanded by Default (IsExpanded="True")

```xml
<Expander Header="Expanded by Default" IsExpanded="True">
    <TextBlock Text="This content is visible on load" Padding="10"/>
</Expander>
```

**Behavior:**
- ✅ Content visible on load
- 👆 Click header to collapse
- 👆 Click again to expand

**Use when**: Content is important enough to show initially

---

### Programmatic Control

You can control expansion from code:

**XAML:**
```xml
<StackPanel>
    <Button Content="Expand All" Click="ExpandAll" Margin="10"/>
    <Button Content="Collapse All" Click="CollapseAll" Margin="10"/>
    
    <Expander x:Name="Expander1" Header="Section 1" Margin="10">
        <TextBlock Text="Content 1" Padding="10"/>
    </Expander>
    
    <Expander x:Name="Expander2" Header="Section 2" Margin="10">
        <TextBlock Text="Content 2" Padding="10"/>
    </Expander>
    
    <Expander x:Name="Expander3" Header="Section 3" Margin="10">
        <TextBlock Text="Content 3" Padding="10"/>
    </Expander>
</StackPanel>
```

**C# Code-behind:**
```csharp
private void ExpandAll(object sender, RoutedEventArgs e)
{
    Expander1.IsExpanded = true;
    Expander2.IsExpanded = true;
    Expander3.IsExpanded = true;
}

private void CollapseAll(object sender, RoutedEventArgs e)
{
    Expander1.IsExpanded = false;
    Expander2.IsExpanded = false;
    Expander3.IsExpanded = false;
}
```

---

### Expanded and Collapsed Events

React to expansion state changes:

**XAML:**
```xml
<Expander Header="Track Expansion" 
          Expanded="OnExpanded" 
          Collapsed="OnCollapsed">
    <TextBlock Text="Content here" Padding="10"/>
</Expander>

<TextBlock x:Name="StatusText" Margin="10"/>
```

**C# Code-behind:**
```csharp
private void OnExpanded(object sender, RoutedEventArgs e)
{
    StatusText.Text = "Expander was expanded!";
}

private void OnCollapsed(object sender, RoutedEventArgs e)
{
    StatusText.Text = "Expander was collapsed!";
}
```

---

## 🧭 ExpandDirection Property

### Controlling Expansion Direction

Expander can expand in **four directions**:

### ExpandDirection="Down" (Default)

Content appears below the header:

```xml
<Expander Header="Expand Down ▼" ExpandDirection="Down">
    <Border Background="LightBlue" Padding="20">
        <TextBlock Text="Content appears below" TextAlignment="Center"/>
    </Border>
</Expander>
```

**Use when**: Standard top-to-bottom layout

---

### ExpandDirection="Up"

Content appears above the header:

```xml
<Expander Header="Expand Up ▲" ExpandDirection="Up">
    <Border Background="LightGreen" Padding="20">
        <TextBlock Text="Content appears above" TextAlignment="Center"/>
    </Border>
</Expander>
```

**Use when**: Header is at bottom (e.g., footer panels)

---

### ExpandDirection="Left"

Content appears to the left of the header:

```xml
<Expander Header="Expand Left ◀" ExpandDirection="Left">
    <Border Background="LightCoral" Padding="20">
        <TextBlock Text="Content appears to the left"/>
    </Border>
</Expander>
```

**Use when**: Horizontal layout, header on right

---

### ExpandDirection="Right"

Content appears to the right of the header:

```xml
<Expander Header="Expand Right ▶" ExpandDirection="Right">
    <Border Background="LightGoldenrodYellow" Padding="20">
        <TextBlock Text="Content appears to the right"/>
    </Border>
</Expander>
```

**Use when**: Horizontal layout, header on left (e.g., side panels)

---

### Visual Comparison

```xml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="*"/>
        <RowDefinition Height="Auto"/>
    </Grid.RowDefinitions>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto"/>
        <ColumnDefinition Width="*"/>
    </Grid.ColumnDefinitions>
    
    <!-- Center content -->
    <Border Grid.Row="0" Grid.Column="1" Background="White" 
            BorderBrush="Black" BorderThickness="1" Padding="20">
        <TextBlock Text="Main Content Area" 
                   HorizontalAlignment="Center" 
                   VerticalAlignment="Center"/>
    </Border>
    
    <!-- Top: Expand Down -->
    <Expander Grid.Row="0" Grid.Column="1" ExpandDirection="Down"
              Header="Top Panel ▼" VerticalAlignment="Top">
        <Border Background="LightBlue" Padding="10">
            <TextBlock Text="Expands Down"/>
        </Border>
    </Expander>
    
    <!-- Bottom: Expand Up -->
    <Expander Grid.Row="1" Grid.Column="1" ExpandDirection="Up"
              Header="Bottom Panel ▲">
        <Border Background="LightGreen" Padding="10">
            <TextBlock Text="Expands Up"/>
        </Border>
    </Expander>
    
    <!-- Left: Expand Right -->
    <Expander Grid.Row="0" Grid.Column="0" ExpandDirection="Right"
              Header="Left Panel ▶">
        <Border Background="LightCoral" Padding="10">
            <TextBlock Text="Expands Right"/>
        </Border>
    </Expander>
    
    <!-- Right: Expand Left (would need Grid.Column="2") -->
</Grid>
```

---

## 🎨 Styling Expander

### Basic Header Styling

```xml
<Expander Margin="10">
    <Expander.Header>
        <StackPanel Orientation="Horizontal">
            <TextBlock Text="📁" FontSize="18" Margin="0,0,10,0"/>
            <TextBlock Text="Styled Header" FontSize="16" FontWeight="Bold"/>
        </StackPanel>
    </Expander.Header>
    
    <Border Background="White" BorderBrush="LightGray" 
            BorderThickness="1" Padding="15">
        <TextBlock Text="Content with custom header" TextWrapping="Wrap"/>
    </Border>
</Expander>
```

---

### Colored Expander

```xml
<Expander Header="Success Message" Background="#D4EDDA" 
          BorderBrush="#C3E6CB" BorderThickness="1" 
          Margin="10" Padding="5">
    <Border Background="White" Padding="15" Margin="5">
        <StackPanel>
            <TextBlock Text="✓ Operation completed successfully!" 
                       Foreground="#155724" FontWeight="Bold"/>
            <TextBlock Text="All items were processed." Margin="0,5,0,0"/>
        </StackPanel>
    </Border>
</Expander>

<Expander Header="Error Details" Background="#F8D7DA" 
          BorderBrush="#F5C6CB" BorderThickness="1" 
          Margin="10" Padding="5">
    <Border Background="White" Padding="15" Margin="5">
        <StackPanel>
            <TextBlock Text="✗ An error occurred" 
                       Foreground="#721C24" FontWeight="Bold"/>
            <TextBlock Text="Check the logs for details." Margin="0,5,0,0"/>
        </StackPanel>
    </Border>
</Expander>
```

---

### Rich Header Content

```xml
<Expander Margin="10">
    <Expander.Header>
        <Grid Width="600">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="Auto"/>
            </Grid.ColumnDefinitions>
            
            <StackPanel Grid.Column="0">
                <TextBlock Text="User Profile" FontSize="16" FontWeight="Bold"/>
                <TextBlock Text="Last updated: 2 hours ago" 
                           FontSize="10" Foreground="Gray"/>
            </StackPanel>
            
            <Button Grid.Column="1" Content="Edit" Padding="10,5"
                    Click="EditProfile"/>
        </Grid>
    </Expander.Header>
    
    <Border Background="White" Padding="20" Margin="5">
        <StackPanel>
            <TextBlock Text="Name: John Doe"/>
            <TextBlock Text="Email: john@example.com"/>
            <TextBlock Text="Role: Administrator"/>
        </StackPanel>
    </Border>
</Expander>
```

---

## 🌟 Real-World Examples

### Example 1: FAQ Section

```xml
<ScrollViewer>
    <StackPanel Margin="20">
        <TextBlock Text="Frequently Asked Questions" 
                   FontSize="24" FontWeight="Bold" 
                   Margin="0,0,0,20"/>
        
        <!-- Question 1 -->
        <Expander Margin="0,5">
            <Expander.Header>
                <TextBlock Text="❓ How do I reset my password?" 
                           FontSize="14" FontWeight="Bold"/>
            </Expander.Header>
            <Border Background="#F8F9FA" Padding="15" Margin="5">
                <TextBlock TextWrapping="Wrap">
                    Click on "Forgot Password" on the login page. 
                    Enter your email address, and we'll send you a 
                    reset link within 5 minutes.
                </TextBlock>
            </Border>
        </Expander>
        
        <!-- Question 2 -->
        <Expander Margin="0,5">
            <Expander.Header>
                <TextBlock Text="❓ What payment methods do you accept?" 
                           FontSize="14" FontWeight="Bold"/>
            </Expander.Header>
            <Border Background="#F8F9FA" Padding="15" Margin="5">
                <TextBlock TextWrapping="Wrap">
                    We accept all major credit cards (Visa, MasterCard, 
                    American Express), PayPal, and bank transfers.
                </TextBlock>
            </Border>
        </Expander>
        
        <!-- Question 3 -->
        <Expander Margin="0,5">
            <Expander.Header>
                <TextBlock Text="❓ How can I contact support?" 
                           FontSize="14" FontWeight="Bold"/>
            </Expander.Header>
            <Border Background="#F8F9FA" Padding="15" Margin="5">
                <StackPanel>
                    <TextBlock TextWrapping="Wrap" Margin="0,0,0,10">
                        You can reach our support team through:
                    </TextBlock>
                    <TextBlock Text="• Email: support@example.com"/>
                    <TextBlock Text="• Phone: 1-800-123-4567"/>
                    <TextBlock Text="• Live Chat: Available 24/7"/>
                </StackPanel>
            </Border>
        </Expander>
        
        <!-- Question 4 -->
        <Expander Margin="0,5">
            <Expander.Header>
                <TextBlock Text="❓ Is there a free trial?" 
                           FontSize="14" FontWeight="Bold"/>
            </Expander.Header>
            <Border Background="#F8F9FA" Padding="15" Margin="5">
                <TextBlock TextWrapping="Wrap">
                    Yes! We offer a 14-day free trial with full access 
                    to all features. No credit card required.
                </TextBlock>
            </Border>
        </Expander>
        
        <!-- Question 5 -->
        <Expander Margin="0,5">
            <Expander.Header>
                <TextBlock Text="❓ Can I cancel my subscription?" 
                           FontSize="14" FontWeight="Bold"/>
            </Expander.Header>
            <Border Background="#F8F9FA" Padding="15" Margin="5">
                <TextBlock TextWrapping="Wrap">
                    Yes, you can cancel anytime. Go to Account Settings 
                    → Subscription → Cancel. You'll have access until 
                    the end of your billing period.
                </TextBlock>
            </Border>
        </Expander>
    </StackPanel>
</ScrollViewer>
```

---

### Example 2: Advanced Filter Panel

```xml
<Expander Header="🔍 Advanced Filters" IsExpanded="True" 
          Margin="10" Padding="10" Background="WhiteSmoke">
    <StackPanel Margin="10">
        <!-- Date Range -->
        <Expander Header="📅 Date Range" Margin="0,5" IsExpanded="True">
            <StackPanel Margin="20,10">
                <StackPanel Orientation="Horizontal" Margin="0,5">
                    <TextBlock Text="From:" Width="60" VerticalAlignment="Center"/>
                    <DatePicker Width="150"/>
                </StackPanel>
                <StackPanel Orientation="Horizontal" Margin="0,5">
                    <TextBlock Text="To:" Width="60" VerticalAlignment="Center"/>
                    <DatePicker Width="150"/>
                </StackPanel>
            </StackPanel>
        </Expander>
        
        <!-- Price Range -->
        <Expander Header="💰 Price Range" Margin="0,5">
            <StackPanel Margin="20,10">
                <StackPanel Orientation="Horizontal" Margin="0,5">
                    <TextBlock Text="Min:" Width="60" VerticalAlignment="Center"/>
                    <TextBox Width="100" Text="0"/>
                </StackPanel>
                <StackPanel Orientation="Horizontal" Margin="0,5">
                    <TextBlock Text="Max:" Width="60" VerticalAlignment="Center"/>
                    <TextBox Width="100" Text="1000"/>
                </StackPanel>
            </StackPanel>
        </Expander>
        
        <!-- Categories -->
        <Expander Header="📂 Categories" Margin="0,5">
            <StackPanel Margin="20,10">
                <CheckBox Content="Electronics" Margin="0,3"/>
                <CheckBox Content="Clothing" Margin="0,3"/>
                <CheckBox Content="Books" Margin="0,3"/>
                <CheckBox Content="Home & Garden" Margin="0,3"/>
            </StackPanel>
        </Expander>
        
        <!-- Brands -->
        <Expander Header="🏷️ Brands" Margin="0,5">
            <StackPanel Margin="20,10">
                <CheckBox Content="Brand A" Margin="0,3"/>
                <CheckBox Content="Brand B" Margin="0,3"/>
                <CheckBox Content="Brand C" Margin="0,3"/>
                <CheckBox Content="Brand D" Margin="0,3"/>
            </StackPanel>
        </Expander>
        
        <!-- Apply Button -->
        <Button Content="Apply Filters" Margin="0,15,0,5" 
                Padding="10,5" Background="Navy" Foreground="White"/>
    </StackPanel>
</Expander>
```

---

### Example 3: Accordion Navigation Menu

```xml
<StackPanel Background="#2C3E50" Width="200">
    <!-- Dashboard -->
    <Expander Background="#34495E" Foreground="White" 
              Margin="0,1" IsExpanded="True">
        <Expander.Header>
            <TextBlock Text="📊 Dashboard" FontWeight="Bold"/>
        </Expander.Header>
        <StackPanel Background="#2C3E50">
            <Button Content="Overview" Style="{StaticResource MenuButtonStyle}"/>
            <Button Content="Analytics" Style="{StaticResource MenuButtonStyle}"/>
            <Button Content="Reports" Style="{StaticResource MenuButtonStyle}"/>
        </StackPanel>
    </Expander>
    
    <!-- Products -->
    <Expander Background="#34495E" Foreground="White" Margin="0,1">
        <Expander.Header>
            <TextBlock Text="📦 Products" FontWeight="Bold"/>
        </Expander.Header>
        <StackPanel Background="#2C3E50">
            <Button Content="All Products" Style="{StaticResource MenuButtonStyle}"/>
            <Button Content="Add New" Style="{StaticResource MenuButtonStyle}"/>
            <Button Content="Categories" Style="{StaticResource MenuButtonStyle}"/>
            <Button Content="Inventory" Style="{StaticResource MenuButtonStyle}"/>
        </StackPanel>
    </Expander>
    
    <!-- Orders -->
    <Expander Background="#34495E" Foreground="White" Margin="0,1">
        <Expander.Header>
            <TextBlock Text="🛒 Orders" FontWeight="Bold"/>
        </Expander.Header>
        <StackPanel Background="#2C3E50">
            <Button Content="All Orders" Style="{StaticResource MenuButtonStyle}"/>
            <Button Content="Pending" Style="{StaticResource MenuButtonStyle}"/>
            <Button Content="Completed" Style="{StaticResource MenuButtonStyle}"/>
        </StackPanel>
    </Expander>
    
    <!-- Customers -->
    <Expander Background="#34495E" Foreground="White" Margin="0,1">
        <Expander.Header>
            <TextBlock Text="👥 Customers" FontWeight="Bold"/>
        </Expander.Header>
        <StackPanel Background="#2C3E50">
            <Button Content="All Customers" Style="{StaticResource MenuButtonStyle}"/>
            <Button Content="Add New" Style="{StaticResource MenuButtonStyle}"/>
            <Button Content="Groups" Style="{StaticResource MenuButtonStyle}"/>
        </StackPanel>
    </Expander>
    
    <!-- Settings -->
    <Expander Background="#34495E" Foreground="White" Margin="0,1">
        <Expander.Header>
            <TextBlock Text="⚙️ Settings" FontWeight="Bold"/>
        </Expander.Header>
        <StackPanel Background="#2C3E50">
            <Button Content="General" Style="{StaticResource MenuButtonStyle}"/>
            <Button Content="Security" Style="{StaticResource MenuButtonStyle}"/>
            <Button Content="Notifications" Style="{StaticResource MenuButtonStyle}"/>
        </StackPanel>
    </Expander>
</StackPanel>
```

---

### Example 4: Product Details with Collapsible Sections

```xml
<ScrollViewer>
    <StackPanel Margin="20">
        <!-- Product Title -->
        <TextBlock Text="Premium Wireless Headphones" 
                   FontSize="24" FontWeight="Bold" 
                   Margin="0,0,0,10"/>
        
        <TextBlock Text="$299.99" FontSize="32" 
                   Foreground="Green" FontWeight="Bold" 
                   Margin="0,0,0,20"/>
        
        <!-- Description - Expanded by default -->
        <Expander Header="📝 Description" IsExpanded="True" 
                  Margin="0,5" Background="White" 
                  BorderBrush="LightGray" BorderThickness="1">
            <Border Padding="15" Background="#FAFAFA">
                <TextBlock TextWrapping="Wrap">
                    Experience premium sound quality with our flagship 
                    wireless headphones. Featuring active noise cancellation, 
                    30-hour battery life, and premium comfort materials.
                </TextBlock>
            </Border>
        </Expander>
        
        <!-- Specifications -->
        <Expander Header="🔧 Technical Specifications" Margin="0,5" 
                  Background="White" BorderBrush="LightGray" 
                  BorderThickness="1">
            <Border Padding="15" Background="#FAFAFA">
                <StackPanel>
                    <TextBlock Text="• Driver: 40mm Dynamic" Margin="0,3"/>
                    <TextBlock Text="• Frequency: 20Hz - 20kHz" Margin="0,3"/>
                    <TextBlock Text="• Impedance: 32 Ohms" Margin="0,3"/>
                    <TextBlock Text="• Battery: 30 hours playback" Margin="0,3"/>
                    <TextBlock Text="• Connectivity: Bluetooth 5.0" Margin="0,3"/>
                    <TextBlock Text="• Weight: 250g" Margin="0,3"/>
                </StackPanel>
            </Border>
        </Expander>
        
        <!-- What's in the Box -->
        <Expander Header="📦 What's in the Box" Margin="0,5" 
                  Background="White" BorderBrush="LightGray" 
                  BorderThickness="1">
            <Border Padding="15" Background="#FAFAFA">
                <StackPanel>
                    <TextBlock Text="✓ Wireless Headphones" Margin="0,3"/>
                    <TextBlock Text="✓ USB-C Charging Cable" Margin="0,3"/>
                    <TextBlock Text="✓ Carrying Case" Margin="0,3"/>
                    <TextBlock Text="✓ 3.5mm Audio Cable" Margin="0,3"/>
                    <TextBlock Text="✓ Quick Start Guide" Margin="0,3"/>
                </StackPanel>
            </Border>
        </Expander>
        
        <!-- Shipping & Returns -->
        <Expander Header="🚚 Shipping & Returns" Margin="0,5" 
                  Background="White" BorderBrush="LightGray" 
                  BorderThickness="1">
            <Border Padding="15" Background="#FAFAFA">
                <StackPanel>
                    <TextBlock TextWrapping="Wrap" Margin="0,0,0,10">
                        <Bold>Shipping:</Bold> Free standard shipping on 
                        orders over $50. Express delivery available.
                    </TextBlock>
                    <TextBlock TextWrapping="Wrap">
                        <Bold>Returns:</Bold> 30-day money-back guarantee. 
                        Product must be in original condition.
                    </TextBlock>
                </StackPanel>
            </Border>
        </Expander>
        
        <!-- Warranty -->
        <Expander Header="🛡️ Warranty Information" Margin="0,5" 
                  Background="White" BorderBrush="LightGray" 
                  BorderThickness="1">
            <Border Padding="15" Background="#FAFAFA">
                <TextBlock TextWrapping="Wrap">
                    This product comes with a 2-year manufacturer warranty 
                    covering defects in materials and workmanship. Extended 
                    warranty options available at checkout.
                </TextBlock>
            </Border>
        </Expander>
        
        <!-- Add to Cart Button -->
        <Button Content="Add to Cart" Padding="15,10" 
                Background="Orange" Foreground="White" 
                FontSize="16" FontWeight="Bold" 
                Margin="0,20,0,0"/>
    </StackPanel>
</ScrollViewer>
```

---

## 🚀 Advanced Techniques

### Technique 1: Accordion Behavior (Only One Expanded)

Make expanders behave like an accordion where only one can be open:

**C# Code-behind:**
```csharp
private Expander currentlyExpanded = null;

private void Expander_Expanded(object sender, RoutedEventArgs e)
{
    Expander expander = sender as Expander;
    
    if (currentlyExpanded != null && currentlyExpanded != expander)
    {
        currentlyExpanded.IsExpanded = false;
    }
    
    currentlyExpanded = expander;
}
```

**XAML:**
```xml
<StackPanel>
    <Expander Header="Section 1" Expanded="Expander_Expanded">
        <TextBlock Text="Content 1" Padding="10"/>
    </Expander>
    <Expander Header="Section 2" Expanded="Expander_Expanded">
        <TextBlock Text="Content 2" Padding="10"/>
    </Expander>
    <Expander Header="Section 3" Expanded="Expander_Expanded">
        <TextBlock Text="Content 3" Padding="10"/>
    </Expander>
</StackPanel>
```

---

### Technique 2: Animated Expander

Add smooth animations to expansion:

**Resource Dictionary:**
```xml
<Style x:Key="AnimatedExpander" TargetType="Expander">
    <Style.Resources>
        <Storyboard x:Key="ExpandAnimation">
            <DoubleAnimation Storyboard.TargetProperty="Opacity"
                           From="0" To="1" Duration="0:0:0.3"/>
        </Storyboard>
    </Style.Resources>
    <Style.Triggers>
        <Trigger Property="IsExpanded" Value="True">
            <Trigger.EnterActions>
                <BeginStoryboard Storyboard="{StaticResource ExpandAnimation}"/>
            </Trigger.EnterActions>
        </Trigger>
    </Style.Triggers>
</Style>
```

---

### Technique 3: Nested Expanders

Create hierarchical collapsible content:

```xml
<Expander Header="📁 Root Folder" IsExpanded="True">
    <StackPanel Margin="20,10">
        <Expander Header="📁 Documents" Margin="0,5">
            <StackPanel Margin="20,10">
                <Expander Header="📁 Work" Margin="0,3">
                    <StackPanel Margin="20,10">
                        <TextBlock Text="📄 Report.docx"/>
                        <TextBlock Text="📄 Presentation.pptx"/>
                    </StackPanel>
                </Expander>
                <Expander Header="📁 Personal" Margin="0,3">
                    <StackPanel Margin="20,10">
                        <TextBlock Text="📄 Resume.pdf"/>
                        <TextBlock Text="📄 Letter.docx"/>
                    </StackPanel>
                </Expander>
            </StackPanel>
        </Expander>
        
        <Expander Header="📁 Pictures" Margin="0,5">
            <StackPanel Margin="20,10">
                <TextBlock Text="🖼️ Vacation.jpg"/>
                <TextBlock Text="🖼️ Family.jpg"/>
            </StackPanel>
        </Expander>
    </StackPanel>
</Expander>
```

---

### Technique 4: Search in Expanders

Add search functionality to filter expanders:

**XAML:**
```xml
<StackPanel>
    <TextBox x:Name="SearchBox" PlaceholderText="Search..." 
             TextChanged="SearchBox_TextChanged" 
             Margin="10" Padding="5"/>
    
    <Expander x:Name="Expander1" Header="Python Tutorial">
        <TextBlock Text="Learn Python programming..." Padding="10"/>
    </Expander>
    <Expander x:Name="Expander2" Header="C# Guide">
        <TextBlock Text="Master C# development..." Padding="10"/>
    </Expander>
    <Expander x:Name="Expander3" Header="JavaScript Basics">
        <TextBlock Text="Web development with JS..." Padding="10"/>
    </Expander>
</StackPanel>
```

**C# Code-behind:**
```csharp
private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
{
    string searchText = SearchBox.Text.ToLower();
    
    // Show/hide expanders based on search
    Expander1.Visibility = Expander1.Header.ToString().ToLower().Contains(searchText) 
        ? Visibility.Visible : Visibility.Collapsed;
    Expander2.Visibility = Expander2.Header.ToString().ToLower().Contains(searchText) 
        ? Visibility.Visible : Visibility.Collapsed;
    Expander3.Visibility = Expander3.Header.ToString().ToLower().Contains(searchText) 
        ? Visibility.Visible : Visibility.Collapsed;
}
```

---

### Technique 5: Save/Restore Expansion State

Remember which expanders were open:

**C# Code-behind:**
```csharp
// Save state
private void SaveExpanderState()
{
    Properties.Settings.Default.Expander1Expanded = Expander1.IsExpanded;
    Properties.Settings.Default.Expander2Expanded = Expander2.IsExpanded;
    Properties.Settings.Default.Expander3Expanded = Expander3.IsExpanded;
    Properties.Settings.Default.Save();
}

// Restore state
private void RestoreExpanderState()
{
    Expander1.IsExpanded = Properties.Settings.Default.Expander1Expanded;
    Expander2.IsExpanded = Properties.Settings.Default.Expander2Expanded;
    Expander3.IsExpanded = Properties.Settings.Default.Expander3Expanded;
}

// Call in Window_Closing and Window_Loaded events
```

---

## 💡 Best Practices

### ✅ DO:

1. **Use clear, descriptive headers** that explain the content
2. **Group related settings** in the same expander
3. **Expand important sections by default** (IsExpanded="True")
4. **Keep content organized** - don't put too much in one expander
5. **Use visual cues** (icons, colors) to distinguish sections
6. **Provide keyboard navigation** (Expander supports Tab/Space/Enter)
7. **Consider mobile/touch** - ensure headers are large enough to tap

### ❌ DON'T:

1. **Don't nest too deeply** (more than 2-3 levels becomes confusing)
2. **Don't hide critical information** in collapsed expanders
3. **Don't use for very short content** (not worth the interaction)
4. **Don't overuse** - too many expanders can be overwhelming
5. **Don't put interactive controls** in headers (they steal clicks)
6. **Don't forget empty states** - handle when content is empty
7. **Don't break accessibility** - ensure screen readers work properly

---

## ⚠️ Common Problems & Solutions

### Problem 1: Header Click Not Working

**Issue:** Buttons or links in header prevent expansion

```xml
<!-- ❌ Problem: Button steals click -->
<Expander>
    <Expander.Header>
        <StackPanel Orientation="Horizontal">
            <TextBlock Text="Header"/>
            <Button Content="Edit" Click="Edit"/>  <!-- Prevents expansion! -->
        </StackPanel>
    </Expander.Header>
</Expander>
```

**Solution:** Handle button click, stop event propagation

```xml
<!-- ✅ Solution: Stop propagation -->
<Expander>
    <Expander.Header>
        <Grid Width="400">
            <TextBlock Text="Header" VerticalAlignment="Center"/>
            <Button Content="Edit" HorizontalAlignment="Right"
                    PreviewMouseDown="Button_PreviewMouseDown"/>
        </Grid>
    </Expander.Header>
</Expander>
```

```csharp
private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
{
    e.Handled = true;  // Prevent expander toggle
    // Handle button click
}
```

---

### Problem 2: Content Jumps When Expanding

**Issue:** Abrupt expansion looks jarring

**Solution:** Enable smooth animation (WPF does this by default, but you can customize)

```xml
<Expander>
    <Expander.Resources>
        <Storyboard x:Key="ExpandStoryboard">
            <DoubleAnimation Storyboard.TargetProperty="Opacity"
                           From="0" To="1" Duration="0:0:0.2"/>
        </Storyboard>
    </Expander.Resources>
</Expander>
```

---

### Problem 3: Too Many Expanders, Hard to Navigate

**Issue:** Long list of expanders is overwhelming

**Solution:** Add search or categorization

```xml
<StackPanel>
    <!-- Search box -->
    <TextBox PlaceholderText="Search..." Margin="10" Padding="5"/>
    
    <!-- Category headers -->
    <TextBlock Text="Basic Settings" FontWeight="Bold" 
               Margin="10,15,10,5" FontSize="14"/>
    <Expander Header="General"/>
    <Expander Header="Display"/>
    
    <TextBlock Text="Advanced Settings" FontWeight="Bold" 
               Margin="10,15,10,5" FontSize="14"/>
    <Expander Header="Developer"/>
    <Expander Header="Debug"/>
</StackPanel>
```

---

### Problem 4: Content Not Visible in ScrollViewer

**Issue:** Expanded content goes off-screen

**Solution:** Always wrap multiple expanders in ScrollViewer

```xml
<!-- ✅ Solution: Wrap in ScrollViewer -->
<ScrollViewer VerticalScrollBarVisibility="Auto">
    <StackPanel>
        <Expander Header="Section 1">...</Expander>
        <Expander Header="Section 2">...</Expander>
        <Expander Header="Section 3">...</Expander>
    </StackPanel>
</ScrollViewer>
```

---

### Problem 5: Expander Header Too Long

**Issue:** Long header text gets cut off

**Solution:** Use TextWrapping or TextTrimming

```xml
<!-- ✅ Solution: Wrap text -->
<Expander>
    <Expander.Header>
        <TextBlock Text="This is a very long header that might need wrapping to display properly"
                   TextWrapping="Wrap" MaxWidth="400"/>
    </Expander.Header>
</Expander>

<!-- ✅ Alternative: Trim with ellipsis -->
<Expander>
    <Expander.Header>
        <TextBlock Text="This is a very long header that will be trimmed"
                   TextTrimming="CharacterEllipsis" Width="300"/>
    </Expander.Header>
</Expander>
```

---

## 📋 Summary

### What We Learned

1. **Expander shows/hides content** to save space
2. **IsExpanded controls visibility** (True/False)
3. **ExpandDirection controls where content appears** (Down, Up, Left, Right)
4. **Headers can be simple text or complex layouts**
5. **Perfect for FAQs, settings, details panels**
6. **Can be styled and animated**
7. **Supports nested expanders** for hierarchical content

### Key Takeaways

✅ **Use Expander to manage screen space efficiently**  
✅ **Keep headers clear and descriptive**  
✅ **Expand important sections by default**  
✅ **Don't nest too deeply**  
✅ **Always wrap in ScrollViewer for multiple expanders**  

### When to Use Expander

| Scenario | Use Expander? |
|----------|---------------|
| FAQ sections | ✅ Perfect |
| Settings panels | ✅ Perfect |
| Product details | ✅ Perfect |
| Navigation menus | ✅ Good (with styling) |
| Filters | ✅ Good |
| Critical information | ❌ No (keep visible) |
| Very short content | ❌ No (not worth it) |
| One-time notifications | ❌ No (use Dialog) |

---

## 🎬 What's Next?

In the next episode, we'll explore **GroupBox** - another way to organize and group related controls!

**Preview:**
- Creating visual groups
- Headers and content organization
- Comparison with Expander
- When to use each

See you in Episode 13! 🚀

---

## 📚 Additional Resources

- [Microsoft Docs: Expander](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/controls/expander)
- [ExpandDirection Enumeration](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.expanddirection)
- [ContentControl Class](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.contentcontrol)

---

**Happy Coding! 🎨✨**
