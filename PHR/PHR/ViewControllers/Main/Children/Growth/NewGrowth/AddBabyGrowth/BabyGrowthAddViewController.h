//
//  BabyGrowthAddViewController.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 6/8/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "BabyGrowth.h"

@interface BabyGrowthAddViewController : Base2ViewController

@property (weak, nonatomic) IBOutlet UIImageView *imageBackground;
@property (weak, nonatomic) IBOutlet PHRDateTimeView *DateTimePicker;
@property (weak, nonatomic) IBOutlet UILabel *labelScreenTitle;
@property (weak, nonatomic) IBOutlet UILabel *labelTitleInput;
@property (weak, nonatomic) IBOutlet UILabel *labelUnit;
@property (weak, nonatomic) IBOutlet PHRTextField *textInput;
@property (weak, nonatomic) IBOutlet UIImageView *imageViewUnit;
@property (weak, nonatomic) IBOutlet DALinedTextView *textfieldNoteParent;
@property (weak, nonatomic) IBOutlet DALinedTextView *textfieldNoteDoctor;
@property (weak, nonatomic) IBOutlet UIButton *btnNoteParent;
@property (weak, nonatomic) IBOutlet UIButton *btnNoteDoctor;

@property (assign, nonatomic) ChartContentType addContentType;
@property (nonatomic,copy) void(^addBabyGrowthCallBack)(BabyGrowth *foodItem);
@property (strong, nonatomic) NSString *growthID;
- (IBAction)onTapBtnNoteParent:(id)sender;
- (IBAction)onTapBtnNoteDoctor:(id)sender;

@end
