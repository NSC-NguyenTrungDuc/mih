//
//  BabyFoodAddViewController.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/16/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "StorageManager.h"

@interface BabyFoodAddViewController : Base2ViewController <PHRSliderDelegate,UITextFieldDelegate, UIActionSheetDelegate>

@property (weak, nonatomic) IBOutlet UIImageView *imageViewBackground;
@property (weak, nonatomic) IBOutlet UIView *viewOpacity;
@property (weak, nonatomic) IBOutlet UIView *viewBlur;
@property (strong, nonatomic) IBOutlet UILabel *labelMealType;
@property (weak, nonatomic) IBOutlet PHRSlider *slider;
@property (weak, nonatomic) IBOutlet UILabel *labelSave;
@property (weak, nonatomic) IBOutlet UIView *viewSave;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintSliderAndSave;
@property (strong, nonatomic) IBOutlet PHRTextField *textFieldFood;

- (IBAction)onTapBtnSave:(id)sender;
- (IBAction)touchChooseMealType:(id)sender;

@property (nonatomic) float defaultValue;
@property (strong, nonatomic) UIImage *imageBackground;
@property (nonatomic,copy) void(^AddCallBack)();
@property (strong, nonatomic) NSString *modelID;
@property (nonatomic, strong) ChildrenFoodModel *foodItem;

@end
