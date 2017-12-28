//
//  FoodChildrenViewController.h
//  PHR
//
//  Created by SonNV1368 on 10/6/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "PHRTextField.h"
#import "ChildrenFoodModel.h"

@interface FoodChildrenViewController : Base2ViewController<UITextFieldDelegate, UIActionSheetDelegate>
@property (weak, nonatomic) IBOutlet UIImageView *imageBackground;

//@property (strong, nonatomic) IBOutlet UILabel *labelDatetimeTitle;
//@property (strong, nonatomic) IBOutlet UILabel *labelDateTime;
//@property (strong, nonatomic) IBOutlet UILabel *line1;

@property (strong, nonatomic) IBOutlet PHRTextField *textFieldFood;
@property (strong, nonatomic) IBOutlet UILabel *labelMealTypeTitle;
@property (strong, nonatomic) IBOutlet UILabel *labelMealType;

@property (strong, nonatomic) IBOutlet UILabel *labelKcalUnit;
@property (strong, nonatomic) IBOutlet UITextField *textFieldKcalType;

@property (weak, nonatomic) IBOutlet PHRDateTimeView *dateTimeFood;

@property (strong, nonatomic) IBOutlet DALinedTextView *textViewNote;

@property (nonatomic, strong) NSString *idBabyFood;

@property (nonatomic, strong) void(^addFoodChildrenCallBack)(ChildrenFoodModel* type);

- (IBAction)touchChooseMealType:(id)sender;

@end
