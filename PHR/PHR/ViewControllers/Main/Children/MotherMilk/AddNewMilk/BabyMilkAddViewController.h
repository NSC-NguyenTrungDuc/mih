//
//  StandardFoodAddViewController.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/16/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "BabyMilkModel.h"
#import "StorageManager.h"

@interface BabyMilkAddViewController : Base2ViewController <MDTabBarDelegate, PHRSliderDelegate>

@property (weak, nonatomic) IBOutlet UIImageView *imageViewBackground;
@property (weak, nonatomic) IBOutlet UIView *viewOpacity;
@property (weak, nonatomic) IBOutlet UIView *viewBlur;
@property (weak, nonatomic) IBOutlet TabbarFourButton *tabbarDuration;
@property (weak, nonatomic) IBOutlet PHRTextField *tfMilkType;
@property (weak, nonatomic) IBOutlet PHRSlider *slider;
@property (weak, nonatomic) IBOutlet PHRSlider *sliderTime;
@property (weak, nonatomic) IBOutlet UILabel *labelSave;
@property (weak, nonatomic) IBOutlet UIView *viewSave;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintSliderAndSave;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintHeightTextField;
- (IBAction)onTapBtnSave:(id)sender;

@property (nonatomic) float defaultValue;
@property (nonatomic) float defaultValueTime;
@property (strong, nonatomic) UIImage *imageBackground;
@property (assign, nonatomic) PHRGroupTypeMilk addContentType;
@property (nonatomic,copy) void(^AddCallBack)(PHRGroupTypeMilk selectedType);
@property (strong, nonatomic) NSString *modelID;
@property (nonatomic) BOOL isEdit;
@property (nonatomic, strong) BabyMilkModel *model;

@end
