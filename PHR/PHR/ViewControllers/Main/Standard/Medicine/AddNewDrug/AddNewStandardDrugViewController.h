//
//  AddNewStandardDrugViewController.h
//  PHR
//
//  Created by BillyMobile on 7/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"

@interface AddNewStandardDrugViewController : Base2ViewController

@property (weak, nonatomic) IBOutlet UILabel *lblDateTime;
@property (weak, nonatomic) IBOutlet UIButton *btnChooseTime;
@property (weak, nonatomic) IBOutlet UITextField *txtDrugName;
@property (weak, nonatomic) IBOutlet UILabel *lblMethod;
@property (weak, nonatomic) IBOutlet UILabel *btnDose;
@property (weak, nonatomic) IBOutlet UILabel *lblDoseValue;
@property (weak, nonatomic) IBOutlet UILabel *lblFrequency;
@property (weak, nonatomic) IBOutlet UILabel *lblFrequencyValue;
@property (weak, nonatomic) IBOutlet UILabel *lblUnit;
@property (weak, nonatomic) IBOutlet UIButton *btnChoseUnit;
@property (weak, nonatomic) IBOutlet UILabel *lblQuantity;
@property (weak, nonatomic) IBOutlet UILabel *lblQuantityValue;
@property (weak, nonatomic) IBOutlet UIImageView *imageViewBackground;
@property (weak, nonatomic) IBOutlet UIView *viewOpacity;
@property (weak, nonatomic) IBOutlet UILabel *lblDrinkDrug;
@property (weak, nonatomic) IBOutlet UILabel *lblExternalDrug;

@property (strong, nonatomic) UIImage *imageBackground;
@property (nonatomic, retain) DrugNote *data;
@property (strong, nonatomic) NSDate *datetime;


@end
