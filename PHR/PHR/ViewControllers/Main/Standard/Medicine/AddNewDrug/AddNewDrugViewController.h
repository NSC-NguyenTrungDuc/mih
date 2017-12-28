//
//  AddNewDrugViewController.h
//  PHR
//
//  Created by BillyMobile on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "DrugNote.h"

@interface AddNewDrugViewController : Base2ViewController

@property (weak, nonatomic) IBOutlet UILabel *lblDrugName;
@property (weak, nonatomic) IBOutlet PHRTextField *txtDrugName;

@property (weak, nonatomic) IBOutlet UILabel *lblUnit;
@property (weak, nonatomic) IBOutlet PHRTextField *txtUnit;

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

@property (nonatomic, retain) DrugNote *data;
@property (nonatomic) Boolean canEdit;

@end