//
//  AddChildrenDrugViewController.h
//  PHR
//
//  Created by BillyMobile on 7/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"

@interface AddChildrenDrugViewController : Base2ViewController<UIActionSheetDelegate>

@property (weak, nonatomic) IBOutlet UIImageView *imageBackground;
@property (weak, nonatomic) IBOutlet UILabel *lblDateTime;
@property (weak, nonatomic) IBOutlet UIButton *btnChooseTime;
@property (weak, nonatomic) IBOutlet UITextField *txtDrugName;
@property (weak, nonatomic) IBOutlet UILabel *lblMethod;

@property (weak, nonatomic) IBOutlet UILabel *lblDose;
@property (weak, nonatomic) IBOutlet UILabel *lblFrequency;
@property (weak, nonatomic) IBOutlet UILabel *lblUnit;
@property (weak, nonatomic) IBOutlet UILabel *lblQuantity;
@property (weak, nonatomic) IBOutlet UIButton *btnSave;
@property (weak, nonatomic) IBOutlet UILabel *lblDoseValue;
@property (weak, nonatomic) IBOutlet UILabel *lblFrequencyValue;
@property (weak, nonatomic) IBOutlet UILabel *lblQuantityValue;
@property (weak, nonatomic) IBOutlet UILabel *lblDrinkDrug;
@property (weak, nonatomic) IBOutlet UILabel *lblExternalDrug;
@property (weak, nonatomic) IBOutlet UIButton *btnChooseUnit;

- (IBAction)actionAddDose:(id)sender;
- (IBAction)actionMinDose:(id)sender;
- (IBAction)actionSaveData:(id)sender;
- (IBAction)actionAddFrequency:(id)sender;
- (IBAction)actionMinFrequency:(id)sender;
- (IBAction)actionAddQuantity:(id)sender;
- (IBAction)actionMinQuantity:(id)sender;
- (IBAction)actionChooseTime:(id)sender;


@property (weak, nonatomic) IBOutlet UIView *viewOpacity;
@property (weak, nonatomic) IBOutlet UIView *viewQuantity;

@property (strong, nonatomic) UIImage *imgBackground;

@property (copy, nonatomic) void (^addDrugCallBack)();
@property (strong, nonatomic) NSString *presID;
@property (assign, nonatomic) BOOL isUpdate;
@property (strong, nonatomic) DrugNote *drugNote;
- (IBAction)actionChooseUnit:(id)sender;
@end
