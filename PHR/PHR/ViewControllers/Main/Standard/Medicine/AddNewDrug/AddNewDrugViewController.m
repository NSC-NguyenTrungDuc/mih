//
//  AddNewDrugViewController.m
//  PHR
//
//  Created by BillyMobile on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "AddNewDrugViewController.h"
#import "UIUtils.h"

@interface AddNewDrugViewController ()

@end

@implementation AddNewDrugViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self initializeAddNewDrug];
//    self.lblDateTime.font = [FontUtils aileronRegularWithSize:12.0];
//    self.txtDateTime.text = self.data.time;
//    [self.txtDateTime setEnabled:NO];
//    self.txtDateTime.font = [FontUtils aileronRegularWithSize:16.0];
    
    [self checkCanEdit];
    
    self.lblDrugName.text = kLocalizedString(kDrugName);
    
    [self.viewDateTime updateTime:[UIUtils dateFromString:self.data.time withFormat:PHR_SERVER_DATE_TIME_FORMAT]];
    
    self.txtDrugName.font = [FontUtils aileronRegularWithSize:12.0];
    self.txtDrugName.text = self.data.drug_name;
    self.txtDrugName.font = [FontUtils aileronRegularWithSize:16.0];
    
    self.lblMethod.font = [FontUtils aileronRegularWithSize:14.0];
    self.lblMethod.text = kLocalizedString(KMethod);
    self.lblMethod.textColor = [UIColor colorWithRed:170.0/255.0 green:170.0/255.0 blue:170.0/255.0 alpha:1.0];
    
    self.lblDrinkDrug.font = [FontUtils aileronRegularWithSize:11.0];
    self.lblDrinkDrug.text = kLocalizedString(kMedicineDrinkDrug);
    
    self.lblExternalDrug.font = [FontUtils aileronRegularWithSize:11.0];
    self.lblExternalDrug.text = kLocalizedString(kMedicineExternalDrug);
    
    
    if([self.data.method isEqualToString:@"1"]){
        self.imgExternalDrug.image = [UIImage imageNamed:@"Icon_external_drug_disabled"];
        self.lblExternalDrug.textColor = [UIColor colorWithRed:170.0/255.0 green:170.0/255.0 blue:170.0/255.0 alpha:1.0];
        self.lblQuantity.hidden = NO;
        self.txtQuantity.hidden = NO;
    }else{
        self.imgDrinkDrug.image = [UIImage imageNamed:@"Icon_drink_drug_disabled"];
        self.lblDrinkDrug.textColor = [UIColor colorWithRed:170.0/255.0 green:170.0/255.0 blue:170.0/255.0 alpha:1.0];
        self.lblQuantity.hidden = YES;
        self.txtQuantity.hidden = YES;
    }
    
    self.lblDose.font = [FontUtils aileronRegularWithSize:12.0];
    self.txtDose.text = self.data.dose;
    [self.txtDose setEnabled:NO];
    self.txtDose.font = [FontUtils aileronRegularWithSize:16.0];
    self.lblDose.text = kLocalizedString(kDoseUnitTime);
    
    self.lblUnit.font = [FontUtils aileronRegularWithSize:12.0];
    self.txtUnit.text = self.data.unit;
    [self.txtUnit setEnabled:NO];
    self.txtUnit.font = [FontUtils aileronRegularWithSize:16.0];
    self.lblUnit.text = kLocalizedString(kTitleMedicineUnit);
    
    self.lblMethod.font = [FontUtils aileronRegularWithSize:12.0];
    
    
    self.lblQuantity.font = [FontUtils aileronRegularWithSize:12.0];
    self.txtQuantity.text =  [NSString stringWithFormat:@"%i", self.data.quantity];
    [self.txtQuantity setEnabled:NO];
    self.txtQuantity.font = [FontUtils aileronRegularWithSize:16.0];
    self.lblQuantity.text = kLocalizedString(kQuantityDay);
    
    self.lblFrequency.font = [FontUtils aileronRegularWithSize:12.0];
    self.txtFrequency.text = [NSString stringWithFormat:@"%i", self.data.frequency];
    [self.txtFrequency setEnabled:NO];
    self.txtFrequency.font = [FontUtils aileronRegularWithSize:16.0];
    self.lblFrequency.text = kLocalizedString(kFrequencyTimeDay);
}

- (void) checkCanEdit{
    if(!self.canEdit){
        [self.txtDrugName setEnabled:NO];
        [self.viewDateTime setClickEnable:NO];
    }
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)initializeAddNewDrug {
//    if (self.type == PHRGroupTypeDiseaes) {
//        [self setupNavigationBarTitle:kLocalizedString(kTitleDiseases) titleIcon:@"icon_title_injuries" rightItem:[self itemRightStandardKey:kAdd]];
//        
//    } else {
        [self setupNavigationBarTitle:kLocalizedString(kTitleMedicine) titleIcon:@"Medicine Note" rightItem:nil];
//    }
}


@end
