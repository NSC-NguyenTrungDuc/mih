//
//  AddNewStandardDrugViewController.m
//  PHR
//
//  Created by BillyMobile on 7/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "AddNewStandardDrugViewController.h"

@interface AddNewStandardDrugViewController ()

@end

@implementation AddNewStandardDrugViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    if(self.data != nil && (id) self.data != [NSNull null]){
        self.datetime = [UIUtils dateFromString:self.data.time withFormat:PHR_SERVER_DATE_TIME_FORMAT];
    }
    [self setUpView];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
}

- (void)setUpView{
    self.view.backgroundColor = [UIColor clearColor];
    self.viewOpacity.backgroundColor = PHR_COLOR_MEDICINE_OVERLAY;
    [self setupNavigationBarTitle:kLocalizedString(kBack) iconLeft:nil iconRight:nil iconMiddle:nil isDismissView:true colorLeft:nil colorRight:nil];
    self.txtDrugName.placeholder = kLocalizedString(kDrugName);
    self.lblMethod.text = kLocalizedString(KMethod);
    self.lblFrequency.text = kLocalizedString(kFrequencyTimeDay);
    self.lblDateTime.text = kLocalizedString(kDATETIME);
    self.lblUnit.text = kLocalizedString(kTitleMedicineUnit);
    self.lblQuantity.text = kLocalizedString(kQuantityDay);
    
//    [self updateTime];
  [self.btnChooseTime setTitle:self.data.time forState:UIControlStateNormal];
    self.txtDrugName.text = self.data.drug_name;
    
    if([self.data.dose intValue] > 9){
        self.lblQuantityValue.text = [NSString stringWithFormat:@"%d",[self.data.dose intValue]];
    }else{
        self.lblQuantityValue.text = [NSString stringWithFormat:@"0%d",[self.data.dose intValue]];
    }

    
    if(self.data.quantity > 9){
        self.lblQuantityValue.text = [NSString stringWithFormat:@"%d",self.data.quantity];
    }else{
        self.lblQuantityValue.text = [NSString stringWithFormat:@"0%d",self.data.quantity];
    }
    
    if(self.data.frequency > 9){
        self.lblFrequencyValue.text = [NSString stringWithFormat:@"%d",self.data.frequency];
    }else{
        self.lblFrequencyValue.text = [NSString stringWithFormat:@"0%d",self.data.frequency];
    }
    
    [self.btnChoseUnit setTitle:self.data.unit forState: UIControlStateNormal];
    DLog(@"Unit %@",self.data.unit);
    
    self.lblDrinkDrug.text = kLocalizedString(kMedicineDrinkDrug);
    self.lblExternalDrug.text = kLocalizedString(kMedicineExternalDrug);
    
    if([self.data.method isEqualToString:@"0C"]){
        self.lblDrinkDrug.textColor = [UIColor blackColor];
        self.lblExternalDrug.textColor = [UIColor lightGrayColor];
        self.lblExternalDrug.font = [FontUtils aileronRegularWithSize:12];
        
        UIColor *color = self.lblExternalDrug.textColor;
        self.lblExternalDrug.layer.shadowColor = [color CGColor];
        self.lblExternalDrug.layer.shadowRadius = 4.0f;
        self.lblExternalDrug.layer.shadowOpacity = .9;
        self.lblExternalDrug.layer.shadowOffset = CGSizeZero;
        self.lblExternalDrug.layer.masksToBounds = NO;
    } else {
        self.lblDrinkDrug.textColor = [UIColor lightGrayColor];
        self.lblDrinkDrug.font = [FontUtils aileronRegularWithSize:12];
        
        UIColor *color = self.lblDrinkDrug.textColor;
        self.lblDrinkDrug.layer.shadowColor = [color CGColor];
        self.lblDrinkDrug.layer.shadowRadius = 4.0f;
        self.lblDrinkDrug.layer.shadowOpacity = .9;
        self.lblDrinkDrug.layer.shadowOffset = CGSizeZero;
        self.lblDrinkDrug.layer.masksToBounds = NO;
        
        self.lblExternalDrug.textColor = [UIColor blackColor];
    }
    
    [self.imageViewBackground setImage:[self.imageBackground applyLowLightEffect]];

}

- (void)updateTime {
    NSMutableAttributedString *titleString;
    
    if([NSUtils checkDateIsToday:self.datetime]) {
        titleString = [[NSMutableAttributedString alloc] initWithString:[NSString stringWithFormat:@"%@ - %@",kLocalizedString(kToday),[UIUtils remiderTimeStringFromDate:_datetime]]] ;
    } else {
        titleString = [[NSMutableAttributedString alloc] initWithString:[self stringDateWithShortFormat]];
    }
    [titleString addAttribute:NSUnderlineStyleAttributeName value:[NSNumber numberWithInteger:(NSUnderlinePatternDot|NSUnderlineStyleSingle)] range:NSMakeRange(0, [titleString length])];
    
    [self.btnChooseTime setAttributedTitle:titleString forState:UIControlStateNormal];
}

- (void)updateTime:(NSDate *)date {
    _datetime = date;
    
    NSMutableAttributedString *titleString;
    
    if([NSUtils checkDateIsToday:date]) {
        titleString = [[NSMutableAttributedString alloc] initWithString:kLocalizedString(kToday)];
    } else {
        titleString = [[NSMutableAttributedString alloc] initWithString:[self stringDateWithShortFormat]];
    }
    [titleString addAttribute:NSUnderlineStyleAttributeName value:[NSNumber numberWithInteger:(NSUnderlinePatternDot|NSUnderlineStyleSingle)] range:NSMakeRange(0, titleString.length)];
    
    
    [self.btnChooseTime setAttributedTitle:titleString forState:UIControlStateNormal];
    [self.btnChooseTime.titleLabel setTextColor:[UIColor blackColor]];
}

- (NSString*)stringDateWithShortFormat{
    return [UIUtils stringDate:self.datetime withFormat:PHR_SERVER_DATE_TIME_FORMAT_FOR_MEDICINE];
    
}
/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

@end
