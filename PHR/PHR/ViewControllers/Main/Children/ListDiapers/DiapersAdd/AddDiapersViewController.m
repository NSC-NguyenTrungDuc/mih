//
//  AddDiapersViewController.m
//  PHR
//
//  Created by BillyMobile on 7/23/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "AddDiapersViewController.h"
#import "FCColorPickerViewController.h"

@interface AddDiapersViewController ()<IQActionSheetPickerViewDelegate,FCColorPickerViewControllerDelegate>{
    NSDate *timeRecord;
    UIColor *colorType;
    BOOL isPoo;
}

@end

@implementation AddDiapersViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self initView];
    // Do any additional setup after loading the view from its nib.
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)initView{
    [self setupNavigationBarTitle:kLocalizedString(kBabyTitleDiaper) iconLeft:@"backMenuBar" iconRight:nil iconMiddle:nil isDismissView:true colorLeft:nil colorRight:nil];
    [self initTabbarDuration];
    [self.imageViewBackground setImage:[self.imageBackground applyLowLightEffect]];
    self.viewAdd.backgroundColor = PHR_COLOR_BABY_DIAPER_MAIN_COLOR;
    //self.view.backgroundColor = [UIColor colorWithRed:238.0/255.0 green:145.0/255.0 blue:128.0/255.0 alpha:1.0];
    [self.viewOpacity setBackgroundColor:PHR_COLOR_BABY_DIAPER_OVERLAY];
    self.lblDateTime.text = kLocalizedString(kDATETIME);
    self.labelSave.text = kLocalizedString(kSave);
    self.lblColor.text = kLocalizedString(kColor);
    self.lblState.text = kLocalizedString(kState);
    timeRecord = [NSDate date];
    self.btnChooseTime.titleLabel.textColor = [UIColor blackColor];
    self.btnChooseState.titleLabel.textColor = [UIColor blackColor];
    [self checkProfileToShowView];
    
    NSMutableAttributedString *titleString;
    
    if([NSUtils checkDateIsToday:timeRecord]) {
        titleString = [[NSMutableAttributedString alloc] initWithString:[NSString stringWithFormat:@"%@ - %@",kLocalizedString(kToday),[UIUtils remiderTimeStringFromDate:timeRecord]]] ;
    } else {
        titleString = [[NSMutableAttributedString alloc] initWithString:[self stringDateWithShortFormat]];
    }
    [titleString addAttribute:NSUnderlineStyleAttributeName value:[NSNumber numberWithInteger:(NSUnderlinePatternDot|NSUnderlineStyleSingle)] range:NSMakeRange(0, [titleString length])];
    
    [self.btnChooseState setArrayChoices:[Diaper arrayState]];
    [self.btnChooseTime setAttributedTitle:titleString forState:UIControlStateNormal];
    self.btnChooseColor.layer.cornerRadius = self.btnChooseColor.frame.size.width/2;
    self.btnChooseColor.backgroundColor = [UIColor colorWithRed:223.0/255.0 green:189.0/255.0 blue:67.0/255.0 alpha:1.0];
    if(self.model != nil && (id)self.model != [NSNull null]){
        [self fillDataToView:self.model];
    } else {
        isPoo = YES;
    }
    
    
}

- (void)fillDataToView:(Diaper *)model {
    NSString *method = model.method;
    timeRecord = [UIUtils dateFromServerTimeString:model.time_pee_poo];
    self.tabbarDuration.enabled = NO;
    NSMutableAttributedString *titleString;
    
    if([NSUtils checkDateIsToday:timeRecord]) {
        titleString = [[NSMutableAttributedString alloc] initWithString:[NSString stringWithFormat:@"%@ - %@",kLocalizedString(kToday),[UIUtils remiderTimeStringFromDate:timeRecord]]] ;
    } else {
        titleString = [[NSMutableAttributedString alloc] initWithString:[self stringDateWithShortFormat]];
    }
    [titleString addAttribute:NSUnderlineStyleAttributeName value:[NSNumber numberWithInteger:(NSUnderlinePatternDot|NSUnderlineStyleSingle)] range:NSMakeRange(0, [titleString length])];
    
    [self.btnChooseTime setAttributedTitle:titleString forState:UIControlStateNormal];
    
    if ([method isEqualToString:@"Poo"] || [method isEqualToString:@"うんち"]) {
        isPoo = YES;
        colorType = [UIUtils colorFromHexString:model.color];
        self.btnChooseColor.backgroundColor = colorType;
        self.viewState.hidden = NO;
        self.viewColor.hidden = NO;
        self.tabbarDuration.selectedIndex = 0;
        [self.btnChooseState setText:model.state];
    }
    else {
        isPoo = NO;
        self.viewState.hidden = YES;
        self.viewColor.hidden = YES;
        self.tabbarDuration.selectedIndex = 1;
    }
}

- (NSString*)stringDateWithShortFormat{
    return [UIUtils stringDate:timeRecord withFormat:PHR_SERVER_DATE_TIME_FORMAT_FOR_MEDICINE];
}

- (void)checkProfileToShowView {
    if (![PHRAppStatus checkCurrentBabyActive]) {
        [self.viewAdd setHidden:YES];
    } else {
        [self.viewAdd setHidden:NO];
    }
}

- (void)initTabbarDuration {
    self.tabbarDuration.delegate = self;
    [self.tabbarDuration initContentWhiteTransperent:@[[NSString stringWithFormat:@"%@%@",@"᛫",kLocalizedString(kPoo)],[NSString stringWithFormat:@"%@%@",@"᛫",kLocalizedString(kPee)]] colorSelected:PHR_COLOR_BABY_DIAPER_MAIN_COLOR andUnselectedColor:PHR_COLOR_TABBAR_DURATION_UNSELECTED textFont:[FontUtils aileronLightWithSize:14.0] selectedFont:[FontUtils aileronBoldWithSize:14.0]];

    self.tabbarDuration.selectedIndex = 0;
   
   
}

#pragma mark - MDTABBAR delegate
- (void)tabBar:(MDTabBar *)tabBar didChangeSelectedIndex:(NSUInteger)selectedIndex {
    if(selectedIndex == 0){
        isPoo = YES;
        self.viewState.hidden = NO;
        self.viewColor.hidden = NO;
    } else {
        isPoo = NO;
        self.viewState.hidden = YES;
        self.viewColor.hidden = YES;
    }
}

- (IBAction)actionChooseTime:(id)sender {
    IQActionSheetPickerView *picker = [[IQActionSheetPickerView alloc] initWithTitle:nil delegate:self];
    [picker setTag:2];
    [picker setActionSheetPickerStyle:IQActionSheetPickerStyleDateTimePicker];
    [picker setMaximumDate:[NSDate date]];
    picker.backgroundColor = [UIColor colorWithRed:1.0 green:1.0 blue:1.0 alpha:1.0];
    [picker show];
}

- (IBAction)actionChooseState:(id)sender {
}

- (IBAction)actionChooseColor:(id)sender {
    FCColorPickerViewController *colorPicker = [FCColorPickerViewController colorPickerWithColor:colorType
                                                                                        delegate:self];
    colorPicker.tintColor = [UIColor whiteColor];
    [colorPicker setModalPresentationStyle:UIModalPresentationFormSheet];
    [self presentViewController:colorPicker
                       animated:YES
                     completion:nil];
}

- (IBAction)actionSaveData:(id)sender {
    Diaper *babyDiaper = [[Diaper alloc] init];
    babyDiaper.alert = [NSString stringWithFormat:@"1"];
    NSString* colorString = @"";
    if(colorType != nil){
        colorString = [UIUtils stringFromColor:colorType];
    }else{
        colorString = [UIUtils stringFromColor:[UIColor orangeColor]];
    }
    
    babyDiaper.color = colorString;
    
    if (isPoo) {
        babyDiaper.time_pee_poo = [UIUtils stringUTCFromDateTime:timeRecord];
        babyDiaper.method = kLocalizedString(kPoo);
        babyDiaper.state = [self.btnChooseState getText];
        babyDiaper.note = @"";
    }
    else {
        babyDiaper.time_pee_poo = [UIUtils stringUTCFromDateTime:timeRecord];
        babyDiaper.note = @"";
        babyDiaper.method = kLocalizedString(kPee);
        babyDiaper.state = PHR_STR_NULL;
    }
    
    if (self.babyDiaperID == 0) {
        [self saveForMedicineNoteViewWithObj:babyDiaper];
    }
    else {
        babyDiaper.diaperID = [NSString stringWithFormat:@"%@",self.babyDiaperID];
        
        [[PHRClient instance] requestUpdateDiaper:babyDiaper andCompletion:^(MFRession *responseObject) {
            self.addDiaperCallback(babyDiaper);
             [[NSNotificationCenter defaultCenter] postNotificationName:PHRNotificationEditData object:babyDiaper];
            [self dismissViewControllerAnimated:YES completion:nil];
        } error:^(NSString *error) {
            [NSUtils showMessage:[NSString stringWithFormat:@"%@", error.description] withTitle:kLocalizedString(kTitleAlertError)];
        }];
    }
}

- (void)saveForMedicineNoteViewWithObj:(Diaper *)objDiaper {
    [[PHRClient instance] requestAddNewBabyDiaperWithObj:objDiaper andCompleted:^(id result) {
        NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:result] valueForKeyPath:KEY_Content];
        Diaper *callBackDiaper = [Diaper initializeDiaperFrom:newDict];
        self.addDiaperCallback(callBackDiaper);
        [[NSNotificationCenter defaultCenter] postNotificationName:PHRNotificationAddNewData object:callBackDiaper];
        [self dismissViewControllerAnimated:YES completion:nil];
    } error:^(NSString *error) {
        [NSUtils showMessage:[NSString stringWithFormat:@"%@", error.description] withTitle:kLocalizedString(kTitleAlertError)];
    }];
}

- (void)actionSheetPickerView:(IQActionSheetPickerView *)pickerView didSelectDate:(NSDate*)date{
    
    timeRecord = date;
    NSMutableAttributedString *titleString;
    
    if([NSUtils checkDateIsToday:timeRecord]) {
        titleString = [[NSMutableAttributedString alloc] initWithString:[NSString stringWithFormat:@"%@ - %@",kLocalizedString(kToday),[UIUtils remiderTimeStringFromDate:timeRecord]]] ;
    } else {
        titleString = [[NSMutableAttributedString alloc] initWithString:[self stringDateWithShortFormat]];
    }
    [titleString addAttribute:NSUnderlineStyleAttributeName value:[NSNumber numberWithInteger:(NSUnderlinePatternDot|NSUnderlineStyleSingle)] range:NSMakeRange(0, [titleString length])];
    
    [self.btnChooseTime setAttributedTitle:titleString forState:UIControlStateNormal];
}

- (void)colorPickerViewController:(FCColorPickerViewController *)colorPicker
                   didSelectColor:(UIColor *)color {
    self.color = color;
    colorType = color;
    [self dismissViewControllerAnimated:YES completion:nil];
}

- (void)colorPickerViewControllerDidCancel:(FCColorPickerViewController *)colorPicker {
    [self dismissViewControllerAnimated:YES completion:nil];
}

- (void)setColor:(UIColor *)color {
    colorType = [color copy];
    [self.btnChooseColor setBackgroundColor:colorType];
    [self.btnChooseColor setBackgroundColor:colorType];
}


@end
