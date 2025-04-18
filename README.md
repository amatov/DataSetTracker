### DataSet Tracker™

#### This is an application I developed for smartphones, smart glasses, laptop and desktop computers 

#### The app processes images as the phone or iPad is pointed at a scene with moving objects and overlays on the phone screen detection output and motion metrics in real time (see the six demo videos above)

#### In the folder OpenCVvideo, I have uploaded the image processing and feature segmentation results of my algorithm frame by frame; the moving blobs look like missiles. For some of the 501 frames, I have switched the functionality betweem displaying the raw segmentated areas to showing the computed motion tracks

##### I have descriped a clinical application of this real-time computer vision analysis approach here: http://dx.doi.org/10.13140/RG.2.2.25725.13281/1 (5 PDF files) 

##### I described an application for the ex vivo analysis of patient samples in multiple myeloma, acute myeloid leukemia, and myelodysplastic syndromes here: http://dx.doi.org/10.13140/RG.2.2.29049.44644/1 (7 PDF files) 

##### I described an application for drug discovery in glioblastoma here: http://dx.doi.org/10.13140/RG.2.2.11459.58409/2 (2 PDF files) 

##### See also https://www.researchgate.net/publication/382459075_Real-Time_Image_Analysis_Software_Suitable_for_Resource-Constrained_Computing

##### DataSet Tracker is an openCV-based motion tracking software with real-time camera control and analysis using background subtraction and a watershed algorithm to select image features for tracking, coupled with a Lucas-Kanade optical flow display and a statistical representation of the readout parameters. 

##### A demo of the beta version developed in the cross-platform game engine Unity and designed to run on personal computers, smartphones, and smart glasses hardware, and suitable for resource-constrained, on-the-fly computing in microscopes without internet connectivity can be viewed at https://lnkd.in/gHxqxMXe (3 movie files) 

##### The video shows computer vision analysis of the motion of synthetic markers, which mimic live-cell fluorescent microscopy image sequences. Displacement vectors color-coding is used to show the angular direction as well as the speed of motion. A button selection allows changing the display preferences. 

##### The vectors moving to the right are color-coded in shades of yellow and are also displayed in yellow within the right mode of the bimodal histogram. Similarly, the vectors moving to the left are color-coded in shades of red, both on the image overlay and within the left mode of the bimodal histogram in the upper-right corner of the screen. The alternative display option changes the displacement vectors color-coding to showing different shades of green, depending on the speed. Observe that the unimodal histogram to the right is showing that most of the particles move slowly (the light-green peak to the left), while a few particles move very fast (the dark-green distribution tail on the right side). Real-time information on the frames per second analyzed, the average values for the speed, and the angular vector orientations are displayed in the lower-right corner of the screen.  

##### On the left side of the screen, there are sliders in the upper-left corner, which allow setting the (i) the upper limit for the number of detected particles based on an a priori knowledge of the nature of the motion in the analyzed sample, (ii) the level of statistical significance for the particle selection step, i.e., the level of particle detection stringency, (iii) the minimum distance between particles, which is another parameter selection done based on an a priori knowledge of the type of sample for analysis, and (iv) a cut-off for the particle search radius, which limits the maximally allowed displacement and thus the computational cost; this is another parameter, which is selected based on a knowledge of the sample properties. 

##### By providing sample-specific input to the tracking module, the parameters selection allows to limit the computational complexity, to minimize the tracking errors and to deliver the fastest analysis results. The blue buttons in the lower-left corner of the screen allow to change various aspects of the screen display in terms of showing segmentation or tracking results, single-segment tracks (between just two frames) or the aggregated trajectories and, as described above, the color-coding of the vectors (the angles in red and yellow or the speeds in different shades of green).

#### I wrote C# code with James Cumberbatch (Pushbutton) of Brighton and Hove, England.

