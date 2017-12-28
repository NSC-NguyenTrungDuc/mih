//
//  StandardVitalsAddViewController.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/15/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "StorageManager.h"

@interface StandardVitalsAddViewController : Base2ViewController <MDTabBarDelegate, PHRSliderDelegate>

@property (weak, nonatomic) IBOutlet UIImageView *imageViewBackground;
@property (weak, nonatomic) IBOutlet UIView *viewOpacity;
@property (weak, nonatomic) IBOutlet UIView *viewBlur;
@property (weak, nonatomic) IBOutlet TabbarFourButton *tabbarDuration;
@property (weak, nonatomic) IBOutlet PHRSlider *slider;
@property (weak, nonatomic) IBOutlet PHRSlider *sliderHighPressure;
@property (weak, nonatomic) IBOutlet UILabel *labelSave;
@property (weak, nonatomic) IBOutlet UIView *viewSave;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintSliderAndSave;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintHeightHighPressure;
- (IBAction)onTapBtnSave:(id)sender;

@property (nonatomic) float defaultValue;
@property (nonatomic) float defaultValueHigh;
@property (strong, nonatomic) UIImage *imageBackground;
@property (assign, nonatomic) PHRTemperatureChartType addContentType;
@property (nonatomic,copy) void(^addCallBack)(PHRTemperatureChartType selectedType);
@property (strong, nonatomic) NSString *modelID;
@property (nonatomic, strong) TemperaturePhysiologyModel *model;
@end
