# Image Processing with HSI and CMY using C#

This project focuses on **digital image processing techniques**, specifically exploring color space manipulation and channel analysis using pure C# (no external libraries).

The implementation includes transformations between color models and direct manipulation of image properties such as **Hue**, **Saturation**, and **Intensity**.

---

## Features

### HSI Color Space Manipulation

The project allows direct manipulation of the HSI channels:

- **Hue (H):** Adjusts the color tone of the image  
- **Saturation (S):** Controls the intensity/purity of the color  
- **Intensity (I):** Modifies the brightness of the image  

These operations enable fine-grained control over color perception, commonly used in image enhancement and analysis.

---

### RGB to CMY Conversion

In addition to HSI, the project also performs conversion from the **RGB color model to its complementary CMY model**:

- **C (Cyan)** = 1 - R  
- **M (Magenta)** = 1 - G  
- **Y (Yellow)** = 1 - B  

This transformation is useful for understanding complementary color relationships and alternative color representations.

---

### Grayscale Channel Visualization (HSI)

Each HSI component can be visualized individually in **grayscale**, allowing better inspection of how each channel contributes to the final image:

- Grayscale representation of Hue  
- Grayscale representation of Saturation  
- Grayscale representation of Intensity  

This is particularly useful for debugging and analysis in image processing pipelines.

---

## Tech Stack

- **Language:** C#  
- **Libraries:** None (pure/native implementation)

---

## Acknowledgements

### Color Models and Theory
- [HSI Color Model Explanation](https://www.cs.haifa.ac.il/hagit/courses/ist/Lectures/Demos/ColorApplet2/t_convert.html)
- [RGB to CMY Conversion](https://en.wikipedia.org/wiki/CMY_color_model)
- [Digital Image Processing Concepts](https://homepages.inf.ed.ac.uk/rbf/HIPR2/hipr_top.htm)

### General Image Processing
- [Introduction to Image Processing](https://www.geeksforgeeks.org/digital-image-processing-basics/)
- [Color Spaces Overview](https://en.wikipedia.org/wiki/Color_space)

---

## Authors

- [@GabrielPissininMenossi](https://github.com/GabrielPissininMenossi)  
- [@MthsAmaral](https://github.com/MthsAmaral)  
- [@matheusmen1](https://github.com/matheusmen1)
