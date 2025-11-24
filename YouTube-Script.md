# สคริปต์การสอน: WPF Episode 12 - Expander

## เนื้อหาที่จะสอน

### 1. Expander คืออะไร
- Control สำหรับแสดง/ซ่อนเนื้อหา
- ประหยัดพื้นที่หน้าจอ
- Collapsible Panel

### 2. Expander Properties
- Header - หัวข้อ
- IsExpanded - ขยายหรือยุบ
- ExpandDirection - ทิศทางการขยาย (Down, Up, Left, Right)
- Content - เนื้อหาภายใน

### 3. การใช้งาน
- FAQ Section
- Settings Panel
- Navigation Menu
- Advanced Options

---

## ส่วนที่ 1: Introduction (0:00 - 2:00)

**สวัสดีครับทุกคน**

ยินดีต้อนรับกลับมาสู่ WPF Tutorial Series ของเรา

วันนี้เราจะมาเรียนรู้เกี่ยวกับ **Expander** ซึ่งเป็น Control ที่มีประโยชน์มาก!

Expander ทำอะไร?
- แสดง/ซ่อนเนื้อหาได้
- ประหยัดพื้นที่หน้าจอ
- สร้าง Collapsible Panel

**คิดเหมือนกับตู้เสื้อผ้า - เปิด-ปิดได้!**

เหมาะมากสำหรับ FAQ, Settings, Advanced Options!

---

## ส่วนที่ 2: Expander พื้นฐาน (2:00 - 6:00)

### Demo 2.1: Basic Expander

```xml
<Expander Header="Click to Expand">
    <TextBlock Text="This is the expanded content!" 
               TextWrapping="Wrap" 
               Padding="10"/>
</Expander>
```

**อธิบาย:**
- `Header` - หัวข้อที่คลิกได้
- Content ภายใน - แสดงเมื่อขยาย
- คลิกที่ Header เพื่อเปิด-ปิด

### Demo 2.2: Expander with Styling

```xml
<Expander Header="🔽 Project Details" 
          Background="LightGray"
          Padding="10"
          Margin="5">
    <Border Background="White" 
            Padding="15" 
            Margin="5">
        <StackPanel>
            <TextBlock Text="📌 Name: My Project"/>
            <TextBlock Text="📌 Version: 1.0.0"/>
            <TextBlock Text="📌 Status: Active"/>
        </StackPanel>
    </Border>
</Expander>
```

**ดีอย่างไร:**
- ประหยัดพื้นที่
- ดูเป็นระเบียบ
- ซ่อนรายละเอียดได้

---

## ส่วนที่ 3: IsExpanded Property (6:00 - 10:00)

### Demo 3.1: IsExpanded="True"

```xml
<Expander Header="📂 Expanded by Default" 
          IsExpanded="True">
    <TextBlock Text="This is already expanded when the page loads!" 
               Padding="10"/>
</Expander>
```

**IsExpanded:**
- `True` = ขยายอยู่แล้ว
- `False` = ยุบอยู่ (Default)

### Demo 3.2: Multiple Expanders

```xml
<StackPanel>
    <Expander Header="Section 1" IsExpanded="True" Margin="5">
        <TextBlock Text="Content for Section 1" Padding="10"/>
    </Expander>
    
    <Expander Header="Section 2" Margin="5">
        <TextBlock Text="Content for Section 2" Padding="10"/>
    </Expander>
    
    <Expander Header="Section 3" Margin="5">
        <TextBlock Text="Content for Section 3" Padding="10"/>
    </Expander>
</StackPanel>
```

**User สามารถ:**
- ขยายทีละ Section
- หรือขยายหลาย Section พร้อมกัน
- ปิดที่ไม่ใช้

### Demo 3.3: Binding IsExpanded

```xml
<StackPanel>
    <CheckBox x:Name="ExpandCheckBox" 
              Content="Expand Details" 
              Margin="10"/>
    
    <Expander Header="Details" 
              IsExpanded="{Binding IsChecked, ElementName=ExpandCheckBox}">
        <TextBlock Text="Controlled by CheckBox above!" 
                   Padding="10"/>
    </Expander>
</StackPanel>
```

CheckBox ควบคุม Expander!

---

## ส่วนที่ 4: ExpandDirection (10:00 - 14:00)

### Demo 4.1: ExpandDirection="Down" (Default)

```xml
<Expander Header="⬇️ Expands Down" 
          ExpandDirection="Down">
    <TextBlock Text="Content expands downward" 
               Padding="10" 
               Background="LightBlue"/>
</Expander>
```

### Demo 4.2: ExpandDirection="Up"

```xml
<Expander Header="⬆️ Expands Up" 
          ExpandDirection="Up">
    <TextBlock Text="Content expands upward" 
               Padding="10" 
               Background="LightGreen"/>
</Expander>
```

### Demo 4.3: ExpandDirection="Left"

```xml
<Expander Header="⬅️ Expands Left" 
          ExpandDirection="Left">
    <TextBlock Text="Content expands to the left" 
               Padding="10" 
               Background="LightCoral"/>
</Expander>
```

### Demo 4.4: ExpandDirection="Right"

```xml
<Expander Header="➡️ Expands Right" 
          ExpandDirection="Right">
    <TextBlock Text="Content expands to the right" 
               Padding="10" 
               Background="LightYellow"/>
</Expander>
```

### Demo 4.5: เปรียบเทียบ 4 ทิศทาง

```xml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="*"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="*"/>
        <ColumnDefinition Width="*"/>
    </Grid.ColumnDefinitions>
    
    <Expander Grid.Row="0" Grid.Column="0" 
              Header="⬇️ Down" 
              ExpandDirection="Down" 
              Margin="5">
        <TextBlock Text="Down" Padding="10"/>
    </Expander>
    
    <Expander Grid.Row="0" Grid.Column="1" 
              Header="⬆️ Up" 
              ExpandDirection="Up" 
              Margin="5">
        <TextBlock Text="Up" Padding="10"/>
    </Expander>
    
    <Expander Grid.Row="1" Grid.Column="0" 
              Header="⬅️ Left" 
              ExpandDirection="Left" 
              Margin="5">
        <TextBlock Text="Left" Padding="10"/>
    </Expander>
    
    <Expander Grid.Row="1" Grid.Column="1" 
              Header="➡️ Right" 
              ExpandDirection="Right" 
              Margin="5">
        <TextBlock Text="Right" Padding="10"/>
    </Expander>
</Grid>
```

**โดยปกติใช้ Down มากที่สุด!**

---

## ส่วนที่ 5: Custom Header (14:00 - 18:00)

### Demo 5.1: Rich Header

```xml
<Expander>
    <Expander.Header>
        <StackPanel Orientation="Horizontal">
            <TextBlock Text="👤" FontSize="20" Margin="0,0,10,0"/>
            <StackPanel>
                <TextBlock Text="User Profile" 
                           FontWeight="Bold" 
                           FontSize="14"/>
                <TextBlock Text="Click to view details" 
                           FontSize="11" 
                           Foreground="Gray"/>
            </StackPanel>
        </StackPanel>
    </Expander.Header>
    
    <Border Background="LightGray" Padding="15">
        <StackPanel>
            <TextBlock Text="Name: John Doe"/>
            <TextBlock Text="Email: john@example.com"/>
            <TextBlock Text="Role: Administrator"/>
        </StackPanel>
    </Border>
</Expander>
```

### Demo 5.2: Styled Header

```xml
<Expander>
    <Expander.Header>
        <Border Background="DodgerBlue" 
                CornerRadius="5" 
                Padding="10">
            <TextBlock Text="🔧 Advanced Settings" 
                       Foreground="White" 
                       FontWeight="Bold"/>
        </Border>
    </Expander.Header>
    
    <Border Background="LightBlue" Padding="15">
        <StackPanel>
            <CheckBox Content="Enable logging"/>
            <CheckBox Content="Auto-save" Margin="0,5"/>
            <CheckBox Content="Dark mode" Margin="0,5"/>
        </StackPanel>
    </Border>
</Expander>
```

### Demo 5.3: Header with Count Badge

```xml
<Expander>
    <Expander.Header>
        <StackPanel Orientation="Horizontal">
            <TextBlock Text="📧 Messages" FontWeight="Bold"/>
            <Border Background="Red" 
                    CornerRadius="10" 
                    Padding="5,2" 
                    Margin="10,0">
                <TextBlock Text="12" 
                           Foreground="White" 
                           FontSize="11" 
                           FontWeight="Bold"/>
            </Border>
        </StackPanel>
    </Expander.Header>
    
    <ListBox>
        <ListBoxItem Content="Message 1"/>
        <ListBoxItem Content="Message 2"/>
        <ListBoxItem Content="Message 3"/>
    </ListBox>
</Expander>
```

---

## ส่วนที่ 6: Use Cases (18:00 - 26:00)

### 6.1 FAQ Section

```xml
<StackPanel>
    <TextBlock Text="Frequently Asked Questions" 
               FontSize="24" 
               FontWeight="Bold" 
               Margin="10"/>
    
    <Expander Header="Q1: How to install?" Margin="5">
        <TextBlock Text="A: Download the installer and follow the wizard." 
                   TextWrapping="Wrap" 
                   Padding="10" 
                   Background="LightYellow"/>
    </Expander>
    
    <Expander Header="Q2: What's the system requirement?" Margin="5">
        <TextBlock Text="A: Windows 10 or later, .NET 9.0" 
                   TextWrapping="Wrap" 
                   Padding="10" 
                   Background="LightYellow"/>
    </Expander>
    
    <Expander Header="Q3: Is it free?" Margin="5">
        <TextBlock Text="A: Yes, completely free and open source!" 
                   TextWrapping="Wrap" 
                   Padding="10" 
                   Background="LightYellow"/>
    </Expander>
    
    <Expander Header="Q4: Where to get support?" Margin="5">
        <TextBlock Text="A: Visit our forum at support.example.com" 
                   TextWrapping="Wrap" 
                   Padding="10" 
                   Background="LightYellow"/>
    </Expander>
</StackPanel>
```

### 6.2 Settings Panel

```xml
<StackPanel>
    <TextBlock Text="⚙️ Settings" 
               FontSize="24" 
               FontWeight="Bold" 
               Margin="10"/>
    
    <Expander Header="General Settings" IsExpanded="True" Margin="5">
        <StackPanel Background="White" Padding="15">
            <CheckBox Content="Enable notifications"/>
            <CheckBox Content="Auto-start" Margin="0,5"/>
            <CheckBox Content="Check for updates" Margin="0,5"/>
        </StackPanel>
    </Expander>
    
    <Expander Header="Display Settings" Margin="5">
        <StackPanel Background="White" Padding="15">
            <TextBlock Text="Theme:"/>
            <ComboBox Margin="0,5,0,10">
                <ComboBoxItem Content="Light"/>
                <ComboBoxItem Content="Dark"/>
            </ComboBox>
            
            <TextBlock Text="Font Size:"/>
            <Slider Minimum="10" Maximum="24" Value="14" Margin="0,5"/>
        </StackPanel>
    </Expander>
    
    <Expander Header="Privacy Settings" Margin="5">
        <StackPanel Background="White" Padding="15">
            <CheckBox Content="Share usage data"/>
            <CheckBox Content="Allow cookies" Margin="0,5"/>
            <CheckBox Content="Track location" Margin="0,5"/>
        </StackPanel>
    </Expander>
    
    <Expander Header="Advanced Settings" Margin="5">
        <StackPanel Background="White" Padding="15">
            <CheckBox Content="Developer mode"/>
            <CheckBox Content="Debug logging" Margin="0,5"/>
            <CheckBox Content="Performance monitoring" Margin="0,5"/>
        </StackPanel>
    </Expander>
</StackPanel>
```

### 6.3 Sidebar Navigation

```xml
<Border Width="250" Background="#2C3E50">
    <StackPanel>
        <TextBlock Text="📁 Navigation" 
                   Foreground="White" 
                   FontSize="18" 
                   FontWeight="Bold" 
                   Margin="15,20"/>
        
        <Expander Header="📂 Documents" 
                  Foreground="White" 
                  IsExpanded="True">
            <StackPanel Background="#34495E">
                <Button Content="My Documents" 
                        Background="Transparent" 
                        Foreground="White" 
                        HorizontalAlignment="Stretch" 
                        BorderThickness="0"/>
                <Button Content="Shared" 
                        Background="Transparent" 
                        Foreground="White" 
                        HorizontalAlignment="Stretch" 
                        BorderThickness="0"/>
                <Button Content="Recent" 
                        Background="Transparent" 
                        Foreground="White" 
                        HorizontalAlignment="Stretch" 
                        BorderThickness="0"/>
            </StackPanel>
        </Expander>
        
        <Expander Header="📷 Photos" 
                  Foreground="White" 
                  Margin="0,5,0,0">
            <StackPanel Background="#34495E">
                <Button Content="All Photos" 
                        Background="Transparent" 
                        Foreground="White" 
                        HorizontalAlignment="Stretch" 
                        BorderThickness="0"/>
                <Button Content="Albums" 
                        Background="Transparent" 
                        Foreground="White" 
                        HorizontalAlignment="Stretch" 
                        BorderThickness="0"/>
            </StackPanel>
        </Expander>
        
        <Expander Header="🎵 Music" 
                  Foreground="White" 
                  Margin="0,5,0,0">
            <StackPanel Background="#34495E">
                <Button Content="Playlists" 
                        Background="Transparent" 
                        Foreground="White" 
                        HorizontalAlignment="Stretch" 
                        BorderThickness="0"/>
                <Button Content="Artists" 
                        Background="Transparent" 
                        Foreground="White" 
                        HorizontalAlignment="Stretch" 
                        BorderThickness="0"/>
            </StackPanel>
        </Expander>
    </StackPanel>
</Border>
```

### 6.4 Product Details

```xml
<StackPanel Width="400">
    <Border BorderBrush="Gray" 
            BorderThickness="1" 
            CornerRadius="10" 
            Background="White" 
            Padding="15">
        <StackPanel>
            <TextBlock Text="📱 Product: Smartphone XYZ" 
                       FontSize="20" 
                       FontWeight="Bold" 
                       Margin="0,0,0,10"/>
            
            <TextBlock Text="$599.99" 
                       FontSize="32" 
                       Foreground="Green" 
                       FontWeight="Bold" 
                       Margin="0,0,0,15"/>
            
            <Expander Header="📋 Specifications" Margin="0,5">
                <Border Background="LightGray" Padding="10">
                    <StackPanel>
                        <TextBlock Text="• Display: 6.5 inch OLED"/>
                        <TextBlock Text="• RAM: 8GB"/>
                        <TextBlock Text="• Storage: 256GB"/>
                        <TextBlock Text="• Camera: 48MP"/>
                    </StackPanel>
                </Border>
            </Expander>
            
            <Expander Header="📦 Shipping Info" Margin="0,5">
                <Border Background="LightGray" Padding="10">
                    <StackPanel>
                        <TextBlock Text="• Free shipping"/>
                        <TextBlock Text="• Delivery: 3-5 days"/>
                        <TextBlock Text="• Return: 30 days"/>
                    </StackPanel>
                </Border>
            </Expander>
            
            <Expander Header="💬 Reviews (24)" Margin="0,5">
                <Border Background="LightGray" Padding="10">
                    <StackPanel>
                        <TextBlock Text="⭐⭐⭐⭐⭐ Great phone!"/>
                        <TextBlock Text="⭐⭐⭐⭐ Good value" Margin="0,5"/>
                        <TextBlock Text="⭐⭐⭐⭐⭐ Excellent!" Margin="0,5"/>
                    </StackPanel>
                </Border>
            </Expander>
        </StackPanel>
    </Border>
</StackPanel>
```

---

## ส่วนที่ 7: Events (26:00 - 29:00)

### Demo 7.1: Expanded Event

```xml
<Expander Header="Track Expand/Collapse" 
          Expanded="Expander_Expanded"
          Collapsed="Expander_Collapsed">
    <TextBlock Text="Content here" Padding="10"/>
</Expander>
```

**Code Behind:**
```csharp
private void Expander_Expanded(object sender, RoutedEventArgs e)
{
    MessageBox.Show("Expander was expanded!");
}

private void Expander_Collapsed(object sender, RoutedEventArgs e)
{
    MessageBox.Show("Expander was collapsed!");
}
```

### Demo 7.2: Use Case - Load Data on Expand

```xml
<Expander Header="Load Data on Demand" 
          Expanded="LoadData_Expanded">
    <ListBox x:Name="DataListBox" Height="200"/>
</Expander>
```

**Code Behind:**
```csharp
private void LoadData_Expanded(object sender, RoutedEventArgs e)
{
    // Load data only when expanded
    DataListBox.Items.Clear();
    for (int i = 1; i <= 10; i++)
    {
        DataListBox.Items.Add($"Item {i}");
    }
}
```

**ประโยชน์:** ประหยัด Resources โดยโหลดข้อมูลเมื่อต้องการเท่านั้น!

---

## ส่วนที่ 8: Tips & Best Practices (29:00 - 32:00)

### 8.1 ใช้ Header ที่ชัดเจน

```xml
<!-- ✅ ดี: Header ชัดเจน -->
<Expander Header="📋 Product Specifications">
    <!-- Content -->
</Expander>

<!-- ⚠️ ไม่ดี: Header คลุมเครือ -->
<Expander Header="More">
    <!-- Content -->
</Expander>
```

### 8.2 กำหนด IsExpanded เริ่มต้นให้เหมาะสม

```xml
<!-- ✅ ดี: Section สำคัญขยายไว้ -->
<Expander Header="Important Notice" IsExpanded="True">
    <TextBlock Text="Please read this first!"/>
</Expander>

<!-- ✅ ดี: Section ไม่สำคัญยุบไว้ -->
<Expander Header="Advanced Options">
    <!-- Optional settings -->
</Expander>
```

### 8.3 จัดกลุ่ม Expanders

```xml
<!-- ✅ ดี: จัดกลุ่มตามหัวข้อ -->
<StackPanel>
    <TextBlock Text="Settings" FontSize="20" FontWeight="Bold" Margin="10"/>
    <Expander Header="General"/>
    <Expander Header="Display"/>
    <Expander Header="Privacy"/>
</StackPanel>
```

### 8.4 ระวัง Nested Expanders

```xml
<!-- ⚠️ ระวัง: Expander ซ้อนกันเยอะ อาจสับสน -->
<Expander Header="Level 1">
    <Expander Header="Level 2">
        <Expander Header="Level 3">
            <TextBlock Text="Too deep!"/>
        </Expander>
    </Expander>
</Expander>
```

**แนะนำ:** ไม่ควรซ้อนเกิน 2 ระดับ

---

## ส่วนที่ 9: Wrap Up และ Outro (32:00 - 34:00)

**สรุปสิ่งที่เราได้เรียนรู้วันนี้:**

1. ✅ Expander = แสดง/ซ่อนเนื้อหา
2. ✅ IsExpanded - ควบคุมการขยาย/ยุบ
3. ✅ ExpandDirection - Down, Up, Left, Right
4. ✅ Custom Header - ปรับแต่งหัวข้อได้
5. ✅ Use Cases: FAQ, Settings, Navigation, Product Details
6. ✅ Events: Expanded, Collapsed

**Expander เหมาะสำหรับ:**
- FAQ Section (คำถามที่พบบ่อย)
- Settings Panel (ตั้งค่าแยกกลุ่ม)
- Sidebar Navigation (เมนูด้านข้าง)
- Product Details (รายละเอียดสินค้า)
- Advanced Options (ตัวเลือกขั้นสูง)

**จุดเด่นของ Expander:**
- ประหยัดพื้นที่หน้าจอ
- จัดระเบียบข้อมูล
- ใช้ง่าย
- Flexible

**ในตอนต่อไป:**

เราจะมาเรียนรู้เกี่ยวกับ **GroupBox** ซึ่งเป็น Control สำหรับ
จัดกลุ่ม Controls ที่เกี่ยวข้องกัน มีกรอบและหัวข้อ!

**อย่าลืม:**
- กด Like ถ้าชอบ
- Subscribe เพื่อติดตามตอนต่อไป
- Comment บอกว่าอยากเรียนเรื่องอะไรต่อไป

**ขอบคุณที่รับชมครับ แล้วพบกันใหม่ตอนหน้า สวัสดีครับ!**

---

## เอกสารอ้างอิง

### Official Documentation
- [Expander Class - Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.expander)
- [ExpandDirection Enumeration - Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.expanddirection)

### Properties Reference
```
Header: Object (หัวข้อ - รองรับ String, UIElement)
IsExpanded: Boolean (ขยาย/ยุบ)
ExpandDirection: ExpandDirection Enum
  - Down (Default)
  - Up
  - Left
  - Right
Content: Object (เนื้อหาภายใน)
```

### Events Reference
```csharp
Expanded: RoutedEventHandler (เมื่อขยาย)
Collapsed: RoutedEventHandler (เมื่อยุบ)
```

---

## ExpandDirection Comparison

| Direction | ขยายไปทาง | ใช้เมื่อ | ตัวอย่าง |
|-----------|----------|---------|---------|
| **Down** | ลง | Standard (ใช้บ่อยที่สุด) | FAQ, Settings |
| **Up** | บน | Dropdown from Bottom | Bottom Menu |
| **Left** | ซ้าย | Sidebar (Right) | Right Panel |
| **Right** | ขวา | Sidebar (Left) | Left Navigation |

---

## Tips & Best Practices

1. **Clear Headers**: ใช้ Header ที่บอกเนื้อหาชัดเจน
2. **Default State**: กำหนด IsExpanded ตามความสำคัญ
3. **Grouping**: จัดกลุ่ม Expanders ตามหัวข้อ
4. **Avoid Deep Nesting**: ไม่ควรซ้อนเกิน 2 ระดับ
5. **Icons**: ใช้ Icon ใน Header เพื่อความชัดเจน

---

## Common Mistakes (ข้อผิดพลาดที่พบบ่อย)

### ❌ Header ไม่ชัดเจน
```xml
<!-- ผิด: ไม่รู้ว่ามีอะไร -->
<Expander Header="More">
    <!-- Content -->
</Expander>
```

### ✅ ถูกต้อง
```xml
<Expander Header="📋 Additional Information">
    <!-- Content -->
</Expander>
```

### ❌ ซ้อน Expander ลึกเกินไป
```xml
<!-- ผิด: ซ้อนลึก 4 ชั้น -->
<Expander>
    <Expander>
        <Expander>
            <Expander>
                <TextBlock Text="Too deep!"/>
            </Expander>
        </Expander>
    </Expander>
</Expander>
```

### ✅ ถูกต้อง
```xml
<!-- ซ้อนแค่ 1-2 ชั้น -->
<Expander Header="Category">
    <Expander Header="Sub-category">
        <TextBlock Text="Content"/>
    </Expander>
</Expander>
```

### ❌ ทุก Expander ขยายพร้อมกัน
```xml
<!-- ผิด: ทุกอันขยายไว้ สิ้นเปลืองพื้นที่ -->
<StackPanel>
    <Expander Header="Section 1" IsExpanded="True"/>
    <Expander Header="Section 2" IsExpanded="True"/>
    <Expander Header="Section 3" IsExpanded="True"/>
</StackPanel>
```

### ✅ ถูกต้อง
```xml
<!-- ขยายแค่ที่สำคัญ -->
<StackPanel>
    <Expander Header="Section 1" IsExpanded="True"/>
    <Expander Header="Section 2"/>
    <Expander Header="Section 3"/>
</StackPanel>
```

---

## Code Examples Repository

Source code สำหรับ Episode นี้สามารถดาวน์โหลดได้ที่:
- GitHub: [WPF_Episode12_Expander](https://github.com/koson/WPF_Episode12_Expander)

---

**End of Script**