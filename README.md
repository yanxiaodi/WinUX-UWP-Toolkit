# Personal core features for building universal Windows apps
This is a collection of extensions, XAML controls, converters, behaviors and state triggers to use when building universal Windows apps.

## Contains the following
### VisualStateTriggers
- **ApiInformationTrigger**
  - Used to set visual states based on a string representing a type to see if it is present for the current device.
- **DeviceTrigger**
  - Used to set visual states based on the current device type, i.e. Desktop, Mobile, SurfaceHub etc. 

### XAML Converters
- **BooleanFormatConverter**
  - Converts a boolean value to a string representing the value, e.g. True = Yes, False = No. 
- **BooleanToVisibilityConverter**
  - Converts a boolean value to a Visibility representing the value, e.g. True = Visible, False = Collapsed.
- **DateTimeFormatConverter**
  - Formats a DateTime value using ToString formatting.
- **EmptyStringToVisibilityConverter**
  - Converts an empty string value to a Visibility representing the value, e.g. If string empty, Collapsed, else Visible.
- **EnumToVisibilityConverter**
  - Converts an Enum value to a Visibility based on a matching parameter value. If match, Visible, else Collapsed.
- **InverseBooleanToVisibilityConverter**
  - Like *BooleanToVisibilityConverter* but reversed.
- **MetricHeightFormatConverter**
  - Converts a double meter value, i.e 1.2 (1m 20cm), to a string value represented based on a target unit of measure (metric or imperial).
- **MetricWeightFormatConverter**
  - Like *MetricHeightFormatConverter* but for weight values, i.e. 1.5 (1k 500g). 

### Extensions
- **DoubleExtensions**
  - *ToFileSize()*
    - Converts a double byte value to a file size represented as a string, e.g. 100 = 0.1KB, 1000000000 = 1GB
- **StorageFileExtensions**
  - *GetBasicProperties()*
    - Gets a collection of basic properties from a StorageFile, e.g. Title, Author, DateTaken, Height, Width, Latitude, Longitude.
      - NOTE, not all properties will be returned. The properties are based on the file type and if they exist on the StorageFile.
  -  *GetExtendedProperties()*
    -  Gets a collection of extended properties from a StorageFile, e.g. File name, File size, MIME type, Originating device, Image dimensions, Camera manufacturer/make.
      - NOTE, not all properties will be returned. The properties are based on the file type and if they exist on the StorageFile. 
- **StringExtensions**
  - *IsEmpty()*
    - Extended the string.IsNullOrWhiteSpace(str) method to also check if the string value is a DateTime or int value returning the min values. 
  - *IsValidDate()*
    - Checks whether a DateTime string value is a valid DateTime, i.e. Not null or not minimum value.
