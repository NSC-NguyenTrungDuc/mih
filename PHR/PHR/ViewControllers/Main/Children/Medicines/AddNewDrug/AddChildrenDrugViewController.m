//
//  AddChildrenDrugViewController.m
//  PHR
//
//  Created by BillyMobile on 7/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "AddChildrenDrugViewController.h"

@interface AddChildrenDrugViewController ()<IQActionSheetPickerViewDelegate>{
    int numberOfDose;
    int numberOfFrequency;
    int numberOfQuantity;
    NSString *drugMethod;
}

@property (strong,nonatomic) NSDate *timeRecord;

@end

@implementation AddChildrenDrugViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self setUpView];
    
    UITapGestureRecognizer *singleExternalDrugFingerTap =
    [[UITapGestureRecognizer alloc] initWithTarget:self
                                            action:@selector(handleExternalDrugSingleTap:)];
    
    UITapGestureRecognizer *singleDrinkDrugFingerTap =
    [[UITapGestureRecognizer alloc] initWithTarget:self
                                            action:@selector(handleDrinkDrugSingleTap:)];
    
    [self.lblExternalDrug addGestureRecognizer:singleExternalDrugFingerTap];
    [self.lblDrinkDrug addGestureRecognizer:singleDrinkDrugFingerTap];
    
}

- (void)setUpView{
    self.view.backgroundColor = [UIColor clearColor];
    [self setupNavigationBarTitle:kLocalizedString(kBabyTitleMedicine) iconLeft:@"backMenuBar" iconRight:nil iconMiddle:nil isDismissView:true colorLeft:nil colorRight:nil];
    [self.imageBackground setImage:[self.imgBackground applyLowLightEffect]];
    self.viewOpacity.backgroundColor = PHR_COLOR_MEDICINE_OVERLAY;
    self.btnSave.backgroundColor = [UIColor colorWithRed:238.0/255.0 green:145.0/255.0 blue:128.0/255.0 alpha:1.0];
    self.txtDrugName.placeholder = kLocalizedString(kDrugName);
    self.lblMethod.text = kLocalizedString(KMethod);
    self.lblDose.text = kLocalizedString(kDoseUnitTime);
    self.lblFrequency.text = kLocalizedString(kFrequencyTimeDay);
    self.lblDateTime.text = kLocalizedString(kDATETIME);
    self.lblUnit.text = kLocalizedString(kTitleMedicineUnit);
    self.lblQuantity.text = kLocalizedString(kQuantityDay);
    self.lblDrinkDrug.userInteractionEnabled = YES;
    self.lblExternalDrug.userInteractionEnabled = YES;
    self.btnChooseTime.titleLabel.textColor = [UIColor blackColor];
    self.btnChooseUnit.titleLabel.textColor = [UIColor blackColor];
    
    [self fillData];
    [self checkProfileToShowView];

}

- (void) fillData{
    if(self.presID != nil && (id)self.presID != [NSNull null] && self.isUpdate){
        numberOfDose = [self.drugNote.dose intValue];
        numberOfQuantity = self.drugNote.quantity;
        numberOfFrequency = self.drugNote.frequency;
        drugMethod = self.drugNote.method;
        
        if(numberOfDose > 9){
            self.lblDoseValue.text = self.drugNote.dose;
        }else{
            self.lblDoseValue.text = [NSString stringWithFormat:@"0%@",self.drugNote.dose];
        }
        if(numberOfQuantity > 9){
            self.lblQuantityValue.text = [NSString stringWithFormat:@"%d",self.drugNote.quantity];
        }else{
            self.lblQuantityValue.text = [NSString stringWithFormat:@"0%d",self.drugNote.quantity];
        }
        if(numberOfFrequency > 9){
            self.lblFrequencyValue.text = [NSString stringWithFormat:@"%d",self.drugNote.frequency];
        }else{
            self.lblFrequencyValue.text = [NSString stringWithFormat:@"0%d",self.drugNote.frequency];
        }
        
        self.timeRecord = [NSUtils dateFromString:self.drugNote.time withFormat:PHR_SERVER_DATE_TIME_FORMAT];
        self.txtDrugName.text = self.drugNote.drug_name;
        
        NSMutableAttributedString *titleString;
        
        titleString = [[NSMutableAttributedString alloc] initWithString:self.drugNote.unit];
        
        [titleString addAttribute:NSUnderlineStyleAttributeName value:[NSNumber numberWithInteger:(NSUnderlinePatternDot|NSUnderlineStyleSingle)] range:NSMakeRange(0, [titleString length])];
        
        [self.btnChooseUnit setAttributedTitle:titleString forState:UIControlStateNormal];

        
    }else{
        numberOfDose = 1;
        numberOfFrequency = 1;
        numberOfQuantity = 1;
        drugMethod = @"1";
        self.timeRecord = [NSDate date];
        self.lblDoseValue.text = [NSString stringWithFormat:@"01"];
        self.lblQuantityValue.text = [NSString stringWithFormat:@"01"];
        self.lblFrequencyValue.text = [NSString stringWithFormat:@"01"];
        NSMutableAttributedString *titleString;
        
        titleString = [[NSMutableAttributedString alloc] initWithString:kLocalizedString(kMedicineUnitNothing)];
        
        [titleString addAttribute:NSUnderlineStyleAttributeName value:[NSNumber numberWithInteger:(NSUnderlinePatternDot|NSUnderlineStyleSingle)] range:NSMakeRange(0, [titleString length])];
        
        [self.btnChooseUnit setAttributedTitle:titleString forState:UIControlStateNormal];
    }
    
    self.lblDrinkDrug.text = kLocalizedString(kMedicineDrinkDrug);
    self.lblExternalDrug.text = kLocalizedString(kMedicineExternalDrug);
    
    if([drugMethod isEqualToString:@"1"]){
        self.lblDrinkDrug.textColor = [UIColor blackColor];
        self.lblDrinkDrug.font = [FontUtils aileronRegularWithSize:14];
        self.lblExternalDrug.textColor = [UIColor lightGrayColor];
        self.lblExternalDrug.font = [FontUtils aileronRegularWithSize:12];
        
    }else{
        self.lblExternalDrug.textColor = [UIColor blackColor];
        self.lblExternalDrug.font = [FontUtils aileronRegularWithSize:14];
        self.lblDrinkDrug.textColor = [UIColor lightGrayColor];
        self.lblDrinkDrug.font = [FontUtils aileronRegularWithSize:12];
    }
    
    NSMutableAttributedString *titleString;
    
    if([NSUtils checkDateIsToday:self.timeRecord]) {
        titleString = [[NSMutableAttributedString alloc] initWithString:[NSString stringWithFormat:@"%@ - %@",kLocalizedString(kToday),[UIUtils remiderTimeStringFromDate:self.timeRecord]]] ;
    } else {
        titleString = [[NSMutableAttributedString alloc] initWithString:[self stringDateWithShortFormat]];
    }
    [titleString addAttribute:NSUnderlineStyleAttributeName value:[NSNumber numberWithInteger:(NSUnderlinePatternDot|NSUnderlineStyleSingle)] range:NSMakeRange(0, [titleString length])];
    
    [self.btnChooseTime setAttributedTitle:titleString forState:UIControlStateNormal];

}

- (NSString*)stringDateWithShortFormat{
    return [UIUtils stringDate:self.timeRecord withFormat:PHR_SERVER_DATE_TIME_FORMAT_FOR_MEDICINE];
}

- (void)checkProfileToShowView {
    if (![PHRAppStatus checkCurrentBabyActive]) {
        [self.btnSave setHidden:YES];
    } else {
        [self.btnSave setHidden:NO];
    }
}

- (void)handleExternalDrugSingleTap:(UITapGestureRecognizer *)recognizer {
    drugMethod = @"C";
    self.viewQuantity.hidden = YES;
    self.lblExternalDrug.textColor = [UIColor blackColor];
    self.lblExternalDrug.font = [FontUtils aileronRegularWithSize:14];
    
    self.lblDrinkDrug.textColor = [UIColor lightGrayColor];
    self.lblDrinkDrug.font = [FontUtils aileronRegularWithSize:12];
    
//    UIColor *color = self.lblExternalDrug.textColor;
//    self.lblExternalDrug.layer.shadowColor = [color CGColor];
//    self.lblExternalDrug.layer.shadowRadius = 4.0f;
//    self.lblExternalDrug.layer.shadowOpacity = .9;
//    self.lblExternalDrug.layer.shadowOffset = CGSizeZero;
//    self.lblExternalDrug.layer.masksToBounds = NO;

}

- (void)handleDrinkDrugSingleTap:(UITapGestureRecognizer *)recognizer {
    drugMethod = @"1";
    self.viewQuantity.hidden = NO;
    self.lblDrinkDrug.textColor = [UIColor blackColor];
    self.lblDrinkDrug.font = [FontUtils aileronRegularWithSize:14];
    
    self.lblExternalDrug.textColor = [UIColor lightGrayColor];
    self.lblExternalDrug.font = [FontUtils aileronRegularWithSize:12];
    
//    UIColor *color = self.lblExternalDrug.textColor;
//    self.lblExternalDrug.layer.shadowColor = [color CGColor];
//    self.lblExternalDrug.layer.shadowRadius = 4.0f;
//    self.lblExternalDrug.layer.shadowOpacity = .9;
//    self.lblExternalDrug.layer.shadowOffset = CGSizeZero;
//    self.lblExternalDrug.layer.masksToBounds = NO;

}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (IBAction)actionAddDose:(id)sender {
    numberOfDose ++;
    if(numberOfDose > 9){
        self.lblDoseValue.text = [NSString stringWithFormat:@"%d",numberOfDose];
    }else{
        self.lblDoseValue.text = [NSString stringWithFormat:@"0%d",numberOfDose];
    }

}

- (IBAction)actionMinDose:(id)sender {
    if(numberOfDose < 1){
        
    }else{
        numberOfDose--;
        if(numberOfDose > 9){
            self.lblDoseValue.text = [NSString stringWithFormat:@"%d",numberOfDose];
        }else{
            self.lblDoseValue.text = [NSString stringWithFormat:@"0%d",numberOfDose];
        }
    }
}

- (IBAction)actionSaveData:(id)sender {
    if (self.txtDrugName.text.length > 50){
        [NSUtils showMessage:kLocalizedString(kTextInputLong) withTitle:APP_NAME];
        return;
    }
    
    if(self.isUpdate){
        NSDictionary *params = @{
                                 KEY_Drug_Time:[UIUtils stringUTCFromDateTime:self.timeRecord],
                                 KEY_Name : self.txtDrugName.text,
                                 KEY_Drug_Quantity : [NSString stringWithFormat:@"%@",self.lblQuantityValue.text],
                                 KEY_Unit :  self.btnChooseUnit.titleLabel.text,
                                 KEY_Drug_Method: drugMethod,
                                 KEY_Drug_Dose:self.lblDoseValue.text,
                                 KEY_Drug_Frequency:[NSString stringWithFormat:@"%@",self.lblFrequencyValue.text]};
        
        [self requestUpdateDrug:params andPresId:self.presID andDrugID:self.drugNote.drug_id];
    }else{
        
        NSDictionary *params = @{
                                 KEY_Drug_Time:[UIUtils stringUTCFromDateTime:self.timeRecord],
                                 KEY_Name : self.txtDrugName.text,
                                 KEY_Drug_Quantity : [NSString stringWithFormat:@"%@",self.lblQuantityValue.text],
                                 KEY_Unit :  self.btnChooseUnit.titleLabel.text,
                                 KEY_Drug_Method: drugMethod,
                                 KEY_Drug_Dose:self.lblDoseValue.text,
                                 KEY_Drug_Frequency:[NSString stringWithFormat:@"%@",self.lblFrequencyValue.text]};

        [self requestAddNewDrug:params andPresId:self.presID];
    }
}

- (IBAction)actionAddFrequency:(id)sender {
    numberOfFrequency++;
    if(numberOfFrequency > 9){
        self.lblFrequencyValue.text = [NSString stringWithFormat:@"%d",numberOfFrequency];
    }else{
        self.lblFrequencyValue.text = [NSString stringWithFormat:@"0%d",numberOfFrequency];
    }
}

- (IBAction)actionMinFrequency:(id)sender {
    if(numberOfFrequency < 1){
        
    }else{
        numberOfFrequency--;
        if(numberOfFrequency > 9){
            self.lblFrequencyValue.text = [NSString stringWithFormat:@"%d",numberOfFrequency];
        }else{
            self.lblFrequencyValue.text = [NSString stringWithFormat:@"0%d",numberOfFrequency];
        }
    }
}

- (IBAction)actionAddQuantity:(id)sender {
    numberOfQuantity++;
    if(numberOfQuantity > 9){
        self.lblQuantityValue.text = [NSString stringWithFormat:@"%d",numberOfQuantity];
    }else{
        self.lblQuantityValue.text = [NSString stringWithFormat:@"0%d",numberOfQuantity];
    }
}

- (IBAction)actionMinQuantity:(id)sender {
    if(numberOfQuantity < 1){
        
    }else{
        numberOfQuantity--;
        if(numberOfQuantity > 9){
            self.lblQuantityValue.text = [NSString stringWithFormat:@"%d",numberOfQuantity];
        }else{
            self.lblQuantityValue.text = [NSString stringWithFormat:@"0%d",numberOfQuantity];
        }
    }
}

- (IBAction)actionChooseTime:(id)sender {
    // Date picker
    IQActionSheetPickerView *picker = [[IQActionSheetPickerView alloc] initWithTitle:nil delegate:self];
    [picker setTag:1];
    [picker setActionSheetPickerStyle:IQActionSheetPickerStyleDateTimePicker];
    [picker setMaximumDate:[NSDate date]];
    //[picker setDate:self.datetime];
    [picker show];

}

- (void)actionSheetPickerView:(IQActionSheetPickerView *)pickerView didSelectDate:(NSDate*)date{
    self.timeRecord = date;
    NSMutableAttributedString *titleString;
    
    if([NSUtils checkDateIsToday:self.timeRecord]) {
        titleString = [[NSMutableAttributedString alloc] initWithString:[NSString stringWithFormat:@"%@ - %@",kLocalizedString(kToday),[UIUtils remiderTimeStringFromDate:self.timeRecord]]] ;
    } else {
        titleString = [[NSMutableAttributedString alloc] initWithString:[self stringDateWithShortFormat]];
    }
    [titleString addAttribute:NSUnderlineStyleAttributeName value:[NSNumber numberWithInteger:(NSUnderlinePatternDot|NSUnderlineStyleSingle)] range:NSMakeRange(0, [titleString length])];
    
    [self.btnChooseTime setAttributedTitle:titleString forState:UIControlStateNormal];

    
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
                [self dismissViewControllerAnimated:YES completion:nil];
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
                [self dismissViewControllerAnimated:YES completion:nil];
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
- (IBAction)actionChooseUnit:(id)sender {
    
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
    
    NSMutableAttributedString *titleString;
    
    titleString = [[NSMutableAttributedString alloc] initWithString:[actionSheet buttonTitleAtIndex:buttonIndex]];
    
    [titleString addAttribute:NSUnderlineStyleAttributeName value:[NSNumber numberWithInteger:(NSUnderlinePatternDot|NSUnderlineStyleSingle)] range:NSMakeRange(0, [titleString length])];
    
    [self.btnChooseUnit setAttributedTitle:titleString forState:UIControlStateNormal];
}
@end
