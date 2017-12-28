//
//  AddBabyDrugViewController.h
//  PHR
//
//  Created by BillyMobile on 6/16/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"

@interface AddBabyDrugViewController : Base2ViewController <UIActionSheetDelegate>

@property (weak, nonatomic) IBOutlet UILabel *lblDrugName;
@property (weak, nonatomic) IBOutlet PHRTextField *txtDrugName;

@property (weak, nonatomic) IBOutlet UILabel *lblUnit;
@property (weak, nonatomic) IBOutlet UILabel *lblDose;
@property (weak, nonatomic) IBOutlet PHRTextField *txtDose;

@property (weak, nonatomic) IBOutlet UILabel *lblFrequency;
@property (weak, nonatomic) IBOutlet PHRTextField *txtFrequency;
@property (weak, nonatomic) IBOutlet UILabel *lblQuantity;
@property (weak, nonatomic) IBOutlet PHRTextField *txtQuantity;


@property (weak, nonatomic) IBOutlet PHRDateTimeView *viewDateTime;

@property (weak, nonatomic) IBOutlet UIImageView *imgExternalDrug;
@property (weak, nonatomic) IBOutlet UILabel *lblDrinkDrug;
@property (weak, nonatomic) IBOutlet UILabel *lblExternalDrug;
@property (weak, nonatomic) IBOutlet UIImageView *imgDrinkDrug;
@property (weak, nonatomic) IBOutlet UILabel *lblMethod;
@property (weak, nonatomic) IBOutlet UIView *viewDrinkDrug;
@property (weak, nonatomic) IBOutlet UIView *viewExternalDrug;
@property (weak, nonatomic) IBOutlet UILabel *lblUnitType;

@property (assign, nonatomic) BOOL isUpdate;
@property (strong, nonatomic) DrugNote *drugNote;
@property (copy, nonatomic) void (^addDrugCallBack)();
@property (strong, nonatomic) NSString *presID;

- (IBAction)chooseUnitType:(id)sender;

@end
