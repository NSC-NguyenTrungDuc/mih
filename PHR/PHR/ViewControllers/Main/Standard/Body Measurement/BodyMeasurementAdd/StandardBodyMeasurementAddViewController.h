//
//  StandardBodyMeasurementAddViewController.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/12/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "PHRSlider.h"

@interface StandardBodyMeasurementAddViewController : Base2ViewController <PHRSliderDelegate>

@property (weak, nonatomic) IBOutlet PHRSlider *sliderHeight;
@property (weak, nonatomic) IBOutlet PHRSlider *sliderWeight;
@property (weak, nonatomic) IBOutlet UIView *viewBlur;
@property (weak, nonatomic) IBOutlet UIView *viewOpacity;
@property (weak, nonatomic) IBOutlet UIImageView *imageViewBackground;
@property (weak, nonatomic) IBOutlet UILabel *labelUnit;
@property (weak, nonatomic) IBOutlet UILabel *labelBMIValue;
@property (weak, nonatomic) IBOutlet UILabel *labelSuggestion;
@property (weak, nonatomic) IBOutlet UILabel *labelSave;
@property (weak, nonatomic) IBOutlet UIView *viewSave;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintSliderAndSave;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintSliderHeightAndViewOpacity;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintSliderHeightAndViewBlur;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintSliderHeight;
- (IBAction)onTapBtnSave:(id)sender;

@property (nonatomic) float defaultValue;
@property (strong, nonatomic) UIImage *imageBackground;
@property (assign, nonatomic) BodyMeasurementType addContentType;
@property (nonatomic,copy) void(^AddCallBack)(BodyMeasurementType type);
@property (strong, nonatomic) NSString *modelID;
@property (nonatomic, strong) BodyMeasurementModel *model;
@end
