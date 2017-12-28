//
//  AddBabyDrugViewController.m
//  PHR
//
//  Created by BillyMobile on 6/16/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "AddBabyDrugViewController.h"

@interface AddBabyDrugViewController (){
    NSString *drugMethod;
}

@end

@implementation AddBabyDrugViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self initView];
    
    drugMethod = @"1";
    
    UITapGestureRecognizer *singleExternalDrugFingerTap =
    [[UITapGestureRecognizer alloc] initWithTarget:self
                                            action:@selector(handleExternalDrugSingleTap:)];
    
    UITapGestureRecognizer *singleDrinkDrugFingerTap =
    [[UITapGestureRecognizer alloc] initWithTarget:self
                                            action:@selector(handleDrinkDrugSingleTap:)];
    
    [self.viewExternalDrug addGestureRecognizer:singleExternalDrugFingerTap];
    [self.viewDrinkDrug addGestureRecognizer:singleDrinkDrugFingerTap];
    // Do any additional setup after loading the view from its nib.
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

-(void) initView{
    
    [self setupNavigationBarTitle:kLocalizedString(kTitleMedicine) titleIcon:@"Medicine Note" rightItem:[self itemRightBabyKey:kSave]];
    self.lblDrugName.textColor = [UIColor colorWithRed:170.0/255.0 green:170.0/255.0 blue:170.0/255.0 alpha:1.0];
    self.lblDrugName.font = [FontUtils aileronRegularWithSize:15.0];
    self.lblDrugName.text = kLocalizedString(kDrugName);
    
    self.txtDrugName.font = [FontUtils aileronRegularWithSize:12.0];
    self.txtDrugName.font = [FontUtils aileronRegularWithSize:16.0];
    
    self.lblMethod.font = [FontUtils aileronRegularWithSize:14.0];
    self.lblMethod.text = kLocalizedString(KMethod);
    self.lblMethod.textColor = [UIColor colorWithRed:170.0/255.0 green:170.0/255.0 blue:170.0/255.0 alpha:1.0];
    
    self.lblDrinkDrug.font = [FontUtils aileronRegularWithSize:11.0];
    self.lblDrinkDrug.text = kLocalizedString(kMedicineDrinkDrug);
    
    self.lblExternalDrug.font = [FontUtils aileronRegularWithSize:11.0];
    self.lblExternalDrug.text = kLocalizedString(kMedicineExternalDrug);
    
    if(self.isUpdate){
        [self.viewDateTime updateTime:[UIUtils dateFromString:self.drugNote.time withFormat:PHR_SERVER_DATE_TIME_FORMAT] shortFormat:NO];
        
        
        self.txtDrugName.text = self.drugNote.drug_name;
        self.txtDose.text = [NSString stringWithFormat:@"%@", self.drugNote.dose];
         self.lblUnitType.text = self.drugNote.unit;
        self.txtFrequency.text = [NSString stringWithFormat:@"%i", self.drugNote.frequency];
        
        if([self.drugNote.method isEqualToString:@"1"]){
            self.imgExternalDrug.image = [UIImage imageNamed:@"Icon_external_drug_disabled"];
            self.lblExternalDrug.textColor = [UIColor colorWithRed:170.0/255.0 green:170.0/255.0 blue:170.0/255.0 alpha:1.0];
            self.txtQuantity.text =  [NSString stringWithFormat:@"%i", self.drugNote.quantity];
            self.lblQuantity.hidden = NO;
            self.txtQuantity.hidden = NO;
        }else{
            self.imgDrinkDrug.image = [UIImage imageNamed:@"Icon_drink_drug_disabled"];
            self.lblDrinkDrug.textColor = [UIColor colorWithRed:170.0/255.0 green:170.0/255.0 blue:170.0/255.0 alpha:1.0];
            self.lblQuantity.hidden = YES;
            self.txtQuantity.hidden = YES;
        }
    }

    
    self.lblDose.font = [FontUtils aileronRegularWithSize:12.0];
    self.txtDose.font = [FontUtils aileronRegularWithSize:16.0];
    self.lblDose.text = kLocalizedString(kDoseUnitTime);
    
    self.lblUnit.font = [FontUtils aileronRegularWithSize:12.0];
    self.lblUnitType.font = [FontUtils aileronRegularWithSize:16.0];
    self.lblUnit.text = kLocalizedString(kTitleMedicineUnit);
    
    self.lblMethod.font = [FontUtils aileronRegularWithSize:12.0];
    
    
    self.lblQuantity.font = [FontUtils aileronRegularWithSize:12.0];
    self.txtQuantity.font = [FontUtils aileronRegularWithSize:16.0];
    self.lblQuantity.text = kLocalizedString(kQuantityDay);
    
    self.lblFrequency.font = [FontUtils aileronRegularWithSize:12.0];
    self.txtFrequency.font = [FontUtils aileronRegularWithSize:16.0];
    self.lblFrequency.text = kLocalizedString(kFrequencyTimeDay);

}

- (void)actionNavigationBarItemRight {
    if(self.isUpdate){
        NSDictionary *params = @{
                                 KEY_Drug_Time:self.viewDateTime.stringDateParam,
                                 KEY_Name : self.txtDrugName.text,
                                 KEY_Drug_Quantity : [NSString stringWithFormat:@"%@",self.txtQuantity.text],
                                 KEY_Unit :  self.lblUnitType.text,
                                 KEY_Drug_Method: drugMethod,
                                 KEY_Drug_Dose:self.txtDose.text,
                                 KEY_Drug_Frequency:[NSString stringWithFormat:@"%@",self.txtFrequency.text]};
        
        [self requestUpdateDrug:params andPresId:self.presID andDrugID:self.drugNote.drug_id];
    }else{
        
        NSDictionary *params = @{
                                 KEY_Drug_Time:self.viewDateTime.stringDateParam,
                                 KEY_Name : self.txtDrugName.text,
                                 KEY_Drug_Quantity : [NSString stringWithFormat:@"%@",self.txtQuantity.text],
                                 KEY_Unit :  self.lblUnitType.text,
                                 KEY_Drug_Method: drugMethod,
                                 KEY_Drug_Dose:self.txtDose.text,
                                 KEY_Drug_Frequency:[NSString stringWithFormat:@"%@",self.txtFrequency.text]};

        [self requestAddNewDrug:params andPresId:self.presID];
    }
}


- (void)handleExternalDrugSingleTap:(UITapGestureRecognizer *)recognizer {
    self.imgDrinkDrug.image = [UIImage imageNamed:@"Icon_drink_drug_disabled"];
    self.imgExternalDrug.image = [UIImage imageNamed:@"Icon_external_drug_enabled"];
    self.lblDrinkDrug.textColor = [UIColor colorWithRed:170.0/255.0 green:170.0/255.0 blue:170.0/255.0 alpha:1.0];
    drugMethod = @"C";
    self.lblQuantity.hidden = YES;
    self.txtQuantity.hidden = YES;
    self.lblUnitType.text = @"";
}

- (void)handleDrinkDrugSingleTap:(UITapGestureRecognizer *)recognizer {
    self.imgExternalDrug.image = [UIImage imageNamed:@"Icon_external_drug_disabled"];
    self.imgDrinkDrug.image = [UIImage imageNamed:@"Icon_drink_drug_enabled"];
    self.lblExternalDrug.textColor = [UIColor colorWithRed:170.0/255.0 green:170.0/255.0 blue:170.0/255.0 alpha:1.0];
    drugMethod = @"1";
    self.lblQuantity.hidden = NO;
    self.txtQuantity.hidden = NO;
     self.lblUnitType.text = @"";
}

- (void)requestAddNewDrug:(NSDictionary *)params andPresId:(NSString *)presID{
    [[PHRClient instance] requestAddNewDrug:params andPresID:presID completed:^(id response){
        [PHRAppDelegate hideLoading];
        if (response) {
            BOOL status = [PHRClient getStatusFromResponse:response];
            if(status){
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                
                NSLog(@"%@",newDict);
                self.addDrugCallBack();
                [self.navigationController popViewControllerAnimated:YES];
            } else {
                NSString* message = [PHRClient getMessageFromResponse:response];
                [NSUtils showMessage:kLocalizedString(message) withTitle:APP_NAME];
            }
        }
        
    } error:^(NSString *error){
        [PHRAppDelegate hideLoading];
        [NSUtils showMessage:error withTitle:APP_NAME];
    }];
}

- (void)requestUpdateDrug:(NSDictionary *)params andPresId:(NSString *)presID andDrugID:(NSString *)drugID{
    [[PHRClient instance] requestUpdateDrug:params andPresID:presID andDrugID:drugID completed:^(id response){
        [PHRAppDelegate hideLoading];
        if (response) {
            BOOL status = [PHRClient getStatusFromResponse:response];
            if(status){
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                
                NSLog(@"%@",newDict);
                self.addDrugCallBack();
                [self.navigationController popViewControllerAnimated:YES];
            } else {
                NSString* message = [PHRClient getMessageFromResponse:response];
                [NSUtils showMessage:kLocalizedString(message) withTitle:APP_NAME];
            }
        }
        
    } error:^(NSString *error){
        [PHRAppDelegate hideLoading];
        [NSUtils showMessage:error withTitle:APP_NAME];
    }];
    
}

- (IBAction)chooseUnitType:(id)sender {

    
    UIActionSheet *popup;
    if (!self.lblQuantity.hidden) {
        popup = [[UIActionSheet alloc] initWithTitle:kLocalizedString(kTitleActionSheet) delegate:self cancelButtonTitle:kLocalizedString(kCancel) destructiveButtonTitle:nil otherButtonTitles:
                            kLocalizedString(kMedicineUnitNothing),
                            kLocalizedString(kMedicineUnitSheet),
                            kLocalizedString(kMedicineUnitBook),
                            kLocalizedString(kMedicineUnitSet),
                            kLocalizedString(kMedicineUnitPiece),
                            kLocalizedString(kMedicineUnitCapsuleDrug),
                            kLocalizedString(kMedicineUnitTablets),
                            kLocalizedString(kMedicineUnitBaller),
                            kLocalizedString(kMedicineUnitPackage),
                            kLocalizedString(kMedicineUnitBottle),
                            kLocalizedString(kMedicineUnitBag),
                            kLocalizedString(kMedicineUnitTube),
                            kLocalizedString(kMedicineUnitMilions),
                            kLocalizedString(kMedicineUnitMg),
                            kLocalizedString(kUnitG),
                            kLocalizedString(kMedicineUnitMl),
                            kLocalizedString(kMedicineUnitPipe),
                            kLocalizedString(kMedicineUnitCan),
                            kLocalizedString(kMedicineUnitLeaf),
                            kLocalizedString(kMedicineUnitMgTiter),
                            kLocalizedString(kMedicineUnitTiter),
                            nil];
    } else {
        popup = [[UIActionSheet alloc] initWithTitle:kLocalizedString(kTitleActionSheet) delegate:self cancelButtonTitle:kLocalizedString(kCancel) destructiveButtonTitle:nil otherButtonTitles:
                 kLocalizedString(kMedicineUnitNothing),
                 kLocalizedString(kMedicineUnitSheet),
                 kLocalizedString(kMedicineUnitBook),
                 kLocalizedString(kMedicineUnitSet),
                 kLocalizedString(kMedicineUnitPiece),
                 kLocalizedString(kMedicineUnitCapsuleDrug),
                 kLocalizedString(kMedicineUnitTablets),
                 kLocalizedString(kMedicineUnitBaller),
                 kLocalizedString(kMedicineUnitBottle),
                 kLocalizedString(kMedicineUnitBag),
                 kLocalizedString(kMedicineUnitTube),
                 kLocalizedString(kMedicineUnitAmpouleDrug),
                 kLocalizedString(kUnitG),
                 kLocalizedString(kMedicineUnitMl),
                 kLocalizedString(kMedicineUnitL),
                 kLocalizedString(kMedicineUnitCm2),
                 kLocalizedString(kMedicineUnitPipe),
                 kLocalizedString(kMedicineUnitMBq),
                 kLocalizedString(kMedicineUnitKit),
                 kLocalizedString(kMedicineUnitCan),
                 kLocalizedString(kMedicineUnitTool),
                 kLocalizedString(kMedicineUnitMlg),
                 kLocalizedString(kMedicineUnitBlister),
                 nil];
    }
    [popup showInView:[UIApplication sharedApplication].keyWindow];
}

- (void)actionSheet:(UIActionSheet *)actionSheet clickedButtonAtIndex:(NSInteger)buttonIndex {
    if ([[actionSheet buttonTitleAtIndex:buttonIndex] isEqualToString:kLocalizedString(kCancel)]) {
        return;
    }
    self.lblUnitType.text = [actionSheet buttonTitleAtIndex:buttonIndex];
}
@end
