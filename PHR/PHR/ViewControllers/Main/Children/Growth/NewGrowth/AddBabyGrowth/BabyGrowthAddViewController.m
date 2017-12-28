//
//  BabyGrowthAddViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 6/8/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BabyGrowthAddViewController.h"

@interface BabyGrowthAddViewController () {
    BOOL isDoctorNote;
    NSString* growthType;
}
@property (nonatomic, strong) BabyGrowth *babyGrowth;
@property (nonatomic, strong) BabyGrowthModel *babyModel;

@end

@implementation BabyGrowthAddViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self initData];
    [self initView];
    [self requestDetailBabyGrowthIfNeeded];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    [self setImageToBackgroundBaby:self.imageBackground];
}

- (void)initView {
    self.view.backgroundColor = [UIColor whiteColor];
    [self setupNavigationBarTitle:kLocalizedString(kBabyTitleGrowth) titleIcon:@"Icon_Baby_Growth" rightItem:[self itemRightBabyKey:kSave]];
    
    self.textInput.font = [FontUtils aileronRegularWithSize:32.0];
    [self.textInput setKeyboardType:UIKeyboardTypeDecimalPad];
    //Note
    self.textfieldNoteDoctor.textColor = [UIColor lightGrayColor];
    self.textfieldNoteParent.textColor = [UIColor lightGrayColor];
    [self.btnNoteDoctor.titleLabel setFont:[FontUtils aileronRegularWithSize:14.0]];
    [self.btnNoteParent.titleLabel setFont:[FontUtils aileronRegularWithSize:14.0]];
    
    [self.btnNoteDoctor setTitle:kLocalizedString(kTitleDoctorNote) forState:UIControlStateNormal];
    [self.btnNoteParent setTitle:kLocalizedString(kTitleParentNote) forState:UIControlStateNormal];
    
    if (self.addContentType == ChartContentTypeHeight) {
        self.imageViewUnit.image = [UIImage imageNamed:@"Icon_Height"];
        self.labelTitleInput.text = kLocalizedString(kGrowthHeight);
        self.labelUnit.text = kLocalizedString(kUnitCm);
    } else if (self.addContentType == ChartContentTypeWeight) {
        self.imageViewUnit.image = [UIImage imageNamed:@"Icon_Weight"];
        self.labelTitleInput.text = kLocalizedString(kGrowthWeight);
        self.labelUnit.text = kLocalizedString(kUnitKg);
    }
    [self onTapBtnNoteDoctor:nil];
}

- (void) initData {
    growthType = [NSString stringWithFormat: @"0%ld", self.addContentType + 1];
}

- (void)requestDetailBabyGrowthIfNeeded {
    if (self.growthID && self.growthID != [NSNull class]) {
        __weak __typeof(self) weakSelf = self;
        [[PHRClient instance] requestDetailBabyGrowthWithId:self.growthID babyGrowthType:growthType andCompletion:^(id response) {
            [PHRAppDelegate hideLoading];
            if (response) {
                BOOL status = [PHRClient getStatusFromResponse:response];
                if (!status) {
                    return;
                }
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                if (newDict) {
                    self.babyGrowth = [BabyGrowth initBabyGrowthWithObj:newDict];
                    self.babyGrowth.type  = self.addContentType;
                }
            }
            [weakSelf fillDataToView:self.babyGrowth];
        } error:^(NSString *error) {
            [NSUtils showMessage:[NSString stringWithFormat:@"%@", error.description] withTitle:kLocalizedString(kTitleAlertError)];
        }];
    }
}

- (void)fillDataToView:(BabyGrowth*)babyGrowthItem {
    [self.DateTimePicker updateTime:[UIUtils dateFromServerTimeString:babyGrowthItem.dateTime]];
    self.growthID = babyGrowthItem.growthId;
    
    if (self.addContentType == ChartContentTypeHeight) {
        [self.textInput setText:babyGrowthItem.height];
    } else if (self.addContentType == ChartContentTypeWeight) {
        [self.textInput setText:babyGrowthItem.weight];
    }
    if (babyGrowthItem.parentNote.length == 0) {
        [self onTapBtnNoteDoctor:nil];
        [self.textfieldNoteDoctor setText:[NSString stringWithFormat:@"%@", babyGrowthItem.doctorNote]];
    } else {
        [self onTapBtnNoteParent:nil];
        [self.textfieldNoteParent setText:[NSString stringWithFormat:@"%@", babyGrowthItem.parentNote]];
    }
}

- (BOOL)checkInput {
    //Check empty
    if ((!self.textInput.text || [self.textInput.text isEmpty])) {
        if (self.addContentType == ChartContentTypeHeight) {
            [NSUtils showMessage:kLocalizedString(kHealthMissHeight) withTitle:APP_NAME];
        } else if (self.addContentType == ChartContentTypeWeight) {
            [NSUtils showMessage:kLocalizedString(kHealthMissWeight) withTitle:APP_NAME];
        }
        return false;
    }
    
    // Check length
    if([self.textInput.text length] > 127) {
        [NSUtils showMessage:kLocalizedString(kTextInputLong) withTitle:APP_NAME];
        return false;
    }
    
    //Check format
    if (self.textInput.text && ![self.textInput.text isEmpty]) {
        NSScanner *scannerInput = [NSScanner scannerWithString:self.textInput.text];
        BOOL isNumericInput = [scannerInput scanFloat:NULL] && [scannerInput isAtEnd];
        if (!isNumericInput || !isNumericInput) {
            [NSUtils showMessage:kLocalizedString(kHealthNumberInvalidHeightAndWeight) withTitle:APP_NAME];
            return false;
        }
    }
    return true;
}

- (void)actionBackToPopView {
    [self.navigationController popViewControllerAnimated:YES];
}

- (void)actionNavigationBarItemRight {
    BOOL isInputCorrect = [self checkInput];
    if (!isInputCorrect) {
        return;
    }
    self.babyModel = [[BabyGrowthModel alloc] init];
    // assign if not exist
    if (!self.babyGrowth) {
        self.babyGrowth = [[BabyGrowth alloc] init];
    }
    
    if (self.addContentType == ChartContentTypeHeight) {
        self.babyGrowth.height = self.textInput.text;
        self.babyModel.height = self.textInput.text;
    } else if (self.addContentType == ChartContentTypeWeight) {
        self.babyGrowth.weight = self.textInput.text;
        self.babyModel.weight = self.textInput.text;
    }
    self.babyGrowth.dateTime   = [self.DateTimePicker stringDateParam];
    self.babyModel.time_measure = self.textInput.text;
    if (isDoctorNote) {
        self.babyGrowth.doctorNote = self.textfieldNoteDoctor.text;
        self.babyGrowth.parentNote = PHR_STR_NULL;
        self.babyModel.doctor_note = self.textfieldNoteDoctor.text;
        self.babyModel.parent_note = PHR_STR_NULL;
    }
    else {
        self.babyGrowth.doctorNote = PHR_STR_NULL;
        self.babyGrowth.parentNote = self.textfieldNoteParent.text;
        self.babyModel.doctor_note = PHR_STR_NULL;
        self.babyModel.parent_note = self.textfieldNoteParent.text;
    }

    self.babyGrowth.type  = self.addContentType;
    self.babyModel.type = [NSNumber numberWithInt:self.addContentType];
    
   
    [PHRAppDelegate showLoading];
    if (!self.growthID || [self.growthID isEqual: [NSNull null]]) {
        // Request add item
        [self requestAddNewBabyGrowth];
        
    } else {
        self.babyGrowth.growthId = self.growthID;
         self.babyModel.growth_id = self.growthID;
        [[NSNotificationCenter defaultCenter] postNotificationName:PHRNotificationEditData object:self.babyModel];
        [self requestUpdateBabyGrowth];
    }
}

- (void)requestAddNewBabyGrowth {
    [[PHRClient instance] requestAddNewBabyGrowth:self.babyGrowth completed:^(id response){
        [PHRAppDelegate hideLoading];
        if (response) {
            BOOL status = [PHRClient getStatusFromResponse:response];
            if(status){
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                if (newDict) {
                    self.babyGrowth = [BabyGrowth initBabyGrowthWithObj:newDict];
                    self.babyGrowth.type  = self.addContentType;
                    self.addBabyGrowthCallBack(self.babyGrowth);
                    self.babyModel.growth_id = self.babyGrowth.growthId;
                    [[NSNotificationCenter defaultCenter] postNotificationName:PHRNotificationAddNewData object:self.babyModel];
                }
                
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

- (void)requestUpdateBabyGrowth {
    [[PHRClient instance] requestUpdateBabyGrowth:self.babyGrowth andCompleted:^(id response) {
        [PHRAppDelegate hideLoading];
        if (response) {
            BOOL status = [PHRClient getStatusFromResponse:response];
            if(status){
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                if (newDict) {
                    self.babyGrowth = [BabyGrowth initBabyGrowthWithObj:newDict];
                    self.babyGrowth.type  = self.addContentType;
                    self.addBabyGrowthCallBack(self.babyGrowth);
                }
                [self.navigationController popViewControllerAnimated:YES];
            } else {
                NSString* message = [PHRClient getMessageFromResponse:response];
                [NSUtils showMessage:kLocalizedString(message) withTitle:APP_NAME];
            }
        }
    } error:^(NSString *error) {
        [PHRAppDelegate hideLoading];
        
    }];
}

- (IBAction)onTapBtnNoteParent:(id)sender {
    isDoctorNote = NO;
    [self.btnNoteParent setTitleColor:[UIColor whiteColor] forState:UIControlStateNormal];
    [self.btnNoteDoctor setTitleColor:PHR_COLOR_GRAY forState:UIControlStateNormal];
    
    [self.btnNoteParent setBackgroundImage:[UIImage imageNamed:@"Tab_Bg_Right_Active"] forState:UIControlStateNormal];
    [self.btnNoteDoctor setBackgroundImage:[UIImage imageNamed:@"Tab_Bg_Left"] forState:UIControlStateNormal];
    [self.textfieldNoteDoctor setHidden:YES];
    [self.textfieldNoteParent setHidden:NO];
}

- (IBAction)onTapBtnNoteDoctor:(id)sender {
    isDoctorNote = YES;
    [self.btnNoteDoctor setTitleColor:[UIColor whiteColor] forState:UIControlStateNormal];
    [self.btnNoteParent setTitleColor:PHR_COLOR_GRAY forState:UIControlStateNormal];
    
    [self.btnNoteParent setBackgroundImage:[UIImage imageNamed:@"Tab_Bg_Right"] forState:UIControlStateNormal];
    [self.btnNoteDoctor setBackgroundImage:[UIImage imageNamed:@"Tab_Bg_Left_Active"] forState:UIControlStateNormal];
    [self.textfieldNoteDoctor setHidden:NO];
    [self.textfieldNoteParent setHidden:YES];
}
@end
