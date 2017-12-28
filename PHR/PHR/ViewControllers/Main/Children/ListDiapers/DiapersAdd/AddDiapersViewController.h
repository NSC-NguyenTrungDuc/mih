//
//  AddDiapersViewController.h
//  PHR
//
//  Created by BillyMobile on 7/23/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"

@interface AddDiapersViewController : Base2ViewController<MDTabBarDelegate>
@property (weak, nonatomic) IBOutlet UIImageView *imageViewBackground;
@property (weak, nonatomic) IBOutlet UIView *viewOpacity;
@property (strong, nonatomic) UIImage *imageBackground;
@property (weak, nonatomic) IBOutlet TabbarFourButton *tabbarDuration;
@property (weak, nonatomic) IBOutlet UILabel *lblDateTime;
@property (weak, nonatomic) IBOutlet UIButton *btnChooseTime;
@property (weak, nonatomic) IBOutlet UILabel *lblState;
@property (weak, nonatomic) IBOutlet PHRButtonCombobox *btnChooseState;
@property (weak, nonatomic) IBOutlet UILabel *lblColor;
@property (weak, nonatomic) IBOutlet UIView *viewState;
@property (weak, nonatomic) IBOutlet UIView *viewColor;
@property (weak, nonatomic) IBOutlet UIButton *btnChooseColor;
@property (weak, nonatomic) IBOutlet UIView *viewAdd;
@property (weak, nonatomic) IBOutlet UILabel *labelSave;

- (IBAction)actionChooseTime:(id)sender;
- (IBAction)actionChooseState:(id)sender;
- (IBAction)actionChooseColor:(id)sender;
- (IBAction)actionSaveData:(id)sender;

@property (strong,nonatomic) NSString *babyDiaperID;
@property (copy, nonatomic) void(^addDiaperCallback)(Diaper *type);
@property (strong,nonatomic) Diaper *model;

@end
