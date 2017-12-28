//
//  StandardBodyMeasurementAddViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/12/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "StandardBodyMeasurementAddViewController.h"
#import "StorageManager.h"
#import "MasterDataModel.h"

#define SLIDER_HEIGHT_TAG 1
#define SLIDER_WEIGHT_TAG 2

@interface StandardBodyMeasurementAddViewController () {
    NSString* bodyMeasurementType;
    double valueHeight;
    double valueWeight;
    NSDate *dateTime;
    MasterDataModel *masterDataModel;
}

@end

@implementation StandardBodyMeasurementAddViewController



- (void)viewDidLoad {
    [super viewDidLoad];
    [self initData];
    [self setupView];
    [self requestDetailIfNeeded];
}

- (void) initData {
    valueHeight = 0;
    valueWeight = 0;
    dateTime = [NSDate date];
    masterDataModel = [[MasterDataModel alloc] init];
    if (self.addContentType == BodyMeasurementTypeBodyFat) {
        bodyMeasurementType = @"04";
    } else if (self.addContentType == BodyMeasurementTypeBMI) {
        bodyMeasurementType = @"03";
    } else {
        bodyMeasurementType = [NSString stringWithFormat: @"0%d", (int)self.addContentType + 1];
    }
    [self getMasterDataModel];
}

- (void)getMasterDataModel {
    if (self.addContentType == BodyMeasurementTypeHeight || self.addContentType == BodyMeasurementTypeWeight || self.addContentType == BodyMeasurementTypeBMI) {
        CGPoint meanAndSD = [NSUtils getMeanAndSdValue:NO masterDataType:HKQuantityTypeIdentifierBodyMassIndex];
        masterDataModel.mean = meanAndSD.x;
        masterDataModel.sd = meanAndSD.y;
    }
}

- (NSString*)calculateRankingForBMI:(float)currentValue mean:(float)mean andSd:(float)sd {
    float normalMin = mean - sd;
    float normalMax = mean + sd;
    
    if (currentValue >= normalMin && currentValue <= normalMax) {
        return kLocalizedString(kNormal);
    } else if (currentValue < normalMin) {
        return kLocalizedString(kBMIUnderWeight);
    } else if (currentValue > normalMax) {
        return kLocalizedString(kBMIOverWeight);
    }
    return @"";
}

- (void)initView {
    self.view.backgroundColor = [UIColor clearColor];
    self.viewSave.backgroundColor = PHR_COLOR_BODY_MEASUREMENT_MAIN_COLOR;
    [self setupNavigationBarTitle:kLocalizedString(kTitleBodyMeasurement) iconLeft:@"backMenuBar" iconRight:nil iconMiddle:nil isDismissView:true colorLeft:nil colorRight:nil];
    [self.imageViewBackground setImage:[self.imageBackground applyLowLightEffect]];
    [self.viewOpacity setBackgroundColor:PHR_COLOR_BODY_MEASUREMENT_OVERLAY];
    [self.labelUnit setText:[NSString stringWithFormat:@"%@ %@",kLocalizedString(kBMI),kLocalizedString(kUnitKgM)]];
    [self.labelBMIValue setText:@"0"];
    [self.labelSuggestion setText:@"-"];
    [self.labelSave setText:kLocalizedString(kSave)];
    if (![PHRAppStatus checkCurrentStandardActive] || (self.model && self.model != [NSNull class])) {
        [self.viewSave setHidden:YES];
        self.constraintSliderAndSave.constant = 0 - self.viewSave.bounds.size.height;
    }
}

- (void)initGradient {
    UIColor *colorOne = [UIColor colorWithRed:1.0f green:1.0f blue:1.0f alpha:0.0f];
    UIColor *colorTwo = [UIColor colorWithRed:1.0f green:1.0f blue:1.0f alpha:0.4f];
    UIColor *colorThree = [UIColor colorWithRed:1.0f green:1.0f blue:1.0f alpha:1.0f];
    NSArray *colors = [NSArray arrayWithObjects:(id)colorOne.CGColor, colorTwo.CGColor,colorThree.CGColor, nil];
    NSNumber *stopOne = [NSNumber numberWithFloat:0.2];
    NSNumber *stopTwo = [NSNumber numberWithFloat:0.3];
    NSNumber *stopThree = [NSNumber numberWithFloat:0.5];
    NSArray *locations = [NSArray arrayWithObjects:stopOne, stopTwo,stopThree, nil];
    
    CAGradientLayer *gradientLayer = [CAGradientLayer layer];
    gradientLayer.frame = CGRectMake(self.imageViewBackground.bounds.origin.x, self.imageViewBackground.bounds.origin.y, [UIScreen mainScreen].bounds.size.width, self.imageViewBackground.bounds.size.height);
    gradientLayer.colors = colors;
    gradientLayer.locations = locations;
    if ([self.imageViewBackground.layer sublayers].count > 0) {
        [self.imageViewBackground.layer replaceSublayer:[self.imageViewBackground.layer sublayers][0] with:gradientLayer];
    }
    else{
        [self.imageViewBackground.layer insertSublayer:gradientLayer atIndex:0];
    }
}


- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
  
}

- (void)viewWillLayoutSubviews {
     [super viewWillLayoutSubviews];
      [self initGradient];
}


- (void)setupView {
    [self initSlider];
    [self initView];
    [self initBMIView];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
   
}


- (void)initSlider {
    if ((self.modelID && self.modelID != [NSNull class]) || (self.model && self.model != [NSNull class])) {
        if (self.addContentType == BodyMeasurementTypeHeight) {
            [self.sliderWeight initialize:self andAddTypeName:HKQuantityTypeIdentifierHeight];
        } else if (self.addContentType == BodyMeasurementTypeWeight){
            [self.sliderWeight initialize:self andAddTypeName:HKQuantityTypeIdentifierBodyMass];
        } else if (self.addContentType == BodyMeasurementTypeBodyFat){
            [self.sliderWeight initialize:self andAddTypeName:HKQuantityTypeIdentifierBodyFatPercentage];
        } else if (self.addContentType == BodyMeasurementTypeBMI){
            [self.sliderWeight initialize:self andAddTypeName:HKQuantityTypeIdentifierBodyMassIndex];
        }
    } else {
        if (self.addContentType == BodyMeasurementTypeBodyFat) {
            [self.sliderHeight initialize:self andAddTypeName:HKQuantityTypeIdentifierBodyFatPercentage];
            [self.sliderWeight initialize:self andAddTypeName:HKQuantityTypeIdentifierBodyMass];
        } else {
            [self.sliderHeight initialize:self andAddTypeName:HKQuantityTypeIdentifierHeight];
            [self.sliderWeight initialize:self andAddTypeName:HKQuantityTypeIdentifierBodyMass];
        }
    }
    self.sliderHeight.tag = SLIDER_HEIGHT_TAG;
    self.sliderWeight.tag = SLIDER_WEIGHT_TAG;
}

- (void)initBMIView {
    if (self.addContentType == BodyMeasurementTypeBodyFat) {
         [self hiddenBMIView:YES];
    } else {
         [self hiddenBMIView:NO];
    }
}

- (void)requestDetailIfNeeded {
    if (self.model && self.model != [NSNull class]) {
        [self hideView];
        [self fillDataToView:self.model];
        return;
    }
    if (self.modelID && self.modelID != [NSNull class]) {
        [self hideView];
        __weak __typeof(self) weakSelf = self;
        [[PHRClient instance] requestDetailBodyMeasurementWithId:self.modelID healthType:bodyMeasurementType andCompletion:^(id response) {
            [PHRAppDelegate hideLoading];
            if (response) {
                BOOL status = [PHRClient getStatusFromResponse:response];
                if (!status) {
                    return;
                }
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                if (newDict) {
                    self.model = [BodyMeasurementModel initWithObj:newDict];
                    self.model.type  = self.addContentType;
                }
            }
            [weakSelf fillDataToView:self.model];
        } error:^(NSString *error) {
            [NSUtils showMessage:[NSString stringWithFormat:@"%@", error.description] withTitle:kLocalizedString(kTitleAlertError)];
        }];
    } else {
        [self scrollToDefaultValue];
    }
}

- (void)hideView {
    [self hiddenBMIView:YES];
    [self.sliderHeight setHidden:YES];
    self.constraintSliderHeightAndViewBlur.constant = -120;
    self.constraintSliderHeightAndViewOpacity.constant = -120;
    self.constraintSliderHeight.constant = 0;
    
}

- (void)scrollToDefaultValue {
    if (self.addContentType == BodyMeasurementTypeHeight) {
        [self.sliderHeight scrollToPosition:self.defaultValue];
    } else if (self.addContentType == BodyMeasurementTypeWeight) {
        [self.sliderWeight scrollToPosition:self.defaultValue];
    } else if (self.addContentType == BodyMeasurementTypeBodyFat) {
        [self.sliderHeight scrollToPosition:self.defaultValue];
    } else if (self.addContentType == BodyMeasurementTypeBMI) {
        [self.labelBMIValue setText:@"0"];
    }
}

- (void)fillDataToView:(BodyMeasurementModel*)bodyMeasurementModel {
    
    self.modelID = bodyMeasurementModel.bodyMeasurementID;
    [self.sliderWeight updateTime:[UIUtils dateFromServerTimeString:bodyMeasurementModel.date]];
   
    if (self.addContentType == BodyMeasurementTypeHeight) {
        [self.sliderWeight scrollToPosition:[bodyMeasurementModel.height floatValue]];
    } else if (self.addContentType == BodyMeasurementTypeWeight) {
        [self.sliderWeight scrollToPosition:ceilf([bodyMeasurementModel.weight floatValue] * 100) / 100];
    } else if (self.addContentType == BodyMeasurementTypeBodyFat) {
        [self.sliderWeight scrollToPosition:[bodyMeasurementModel.percentFat floatValue]];
    } else if (self.addContentType == BodyMeasurementTypeBMI) {
        [self.sliderWeight scrollToPosition:[bodyMeasurementModel.bmi floatValue]];
    }
}

- (void)hiddenBMIView:(BOOL)isHidden {
    [self.labelUnit setHidden:isHidden];
    [self.labelBMIValue setHidden:isHidden];
    [self.labelSuggestion setHidden:isHidden];
}

- (void) scrollViewScroll:(PHRSlider*)slider value:(double) valueScroll {
    if (slider.tag == SLIDER_HEIGHT_TAG) {
        valueHeight = valueScroll;
    } else {
        valueWeight = valueScroll;
    }
    [self updateBMIValue];
}

- (void) updateBMIValue {
    if (self.addContentType != BodyMeasurementTypeBodyFat) {
        if (valueHeight == 0 || valueWeight == 0) {
            [self.labelBMIValue setText:@"0"];
            [self.labelSuggestion setText:@"-"];
            return;
        }
        double valueHeightRounded = round(valueHeight * 10) / 10;
        double bmiValue = (round(valueWeight * 10)/10) / ((valueHeightRounded * valueHeightRounded / 10000));
        NSLog(@"%f - %f - %f",bmiValue, round(valueHeight * 10) / 10, round(valueWeight * 10) / 10);
        [self.labelBMIValue setText:[NSString stringWithFormat:@"%.2f", bmiValue]];
        [self.labelSuggestion setText:[self calculateRankingForBMI:bmiValue mean:masterDataModel.mean andSd:masterDataModel.sd]];
    }
}

- (void)dateTimeChanged:(NSDate *)date {
    dateTime = date;
}

// Save PHRSample to DB
- (PHRSample*)savePHRSamleValue:(double)value type:(NSInteger)type date:(NSDate*)date{
    PHRSample *sample = [[PHRSample alloc] init];
    sample.value = value;
    sample.profile_id = PHRAppStatus.masterProfileId;
    sample.type = [PHRSample healthkitTypeFromType:type fromScreen:StandardHomeTypeBodyMeasurement];
    sample.record_date = date;
    sample.source_bundle = [PHRSample bundle];
    sample.synced = 1;
    if ([PHRAppStatus checkCurrentStandardIsMaster]) {
        [[StorageManager instance] savePHRSampleManual:sample];
    }
    return sample;
}


- (void)requestAddListBodyMeasurement:(NSArray*) listSamples withProfileID:(NSString*)profileID andUDID:(NSString*) udid {
    NSMutableArray *listDictionarySample = [[NSMutableArray alloc] init];
    for (int i = 0; i < listSamples.count; i++){
        PHRSample *sample = listSamples[i];
        NSString *healthType;
        if ([sample.type isEqualToString:HKQuantityTypeIdentifierHeight]) {
            healthType = @"01";
        } else if ([sample.type isEqualToString:HKQuantityTypeIdentifierBodyMass]) {
            healthType = @"02";
        } else if ([sample.type isEqualToString:HKQuantityTypeIdentifierBodyFatPercentage]) {
            healthType = @"04";
        } else if ([sample.type isEqualToString:HKQuantityTypeIdentifierBodyMassIndex]) {
            healthType = @"03";
        }
        NSString *strDate = [UIUtils stringUTCFromDateTime:sample.record_date];
        NSDictionary *dictionary = @{KEY_datetime_record : strDate,
                                     KEY_Height : [sample.type isEqualToString:HKQuantityTypeIdentifierHeight] ? @(sample.value).stringValue: @"",
                                     KEY_Weight : [sample.type isEqualToString:HKQuantityTypeIdentifierBodyMass] ? @(sample.value).stringValue : @"",
                                     KEY_PercentageFat : [sample.type isEqualToString:HKQuantityTypeIdentifierBodyFatPercentage] ? @(sample.value).stringValue : @"",
                                     KEY_BMI : [sample.type isEqualToString:HKQuantityTypeIdentifierBodyMassIndex] ? @(sample.value).stringValue : @"",
                                     KEY_HEALTH_TYPE : healthType,
                                     KEY_Note : @"",
                                     KEY_Source : sample.source_bundle};
        NSLog( @"dic: %@", dictionary );
        [listDictionarySample addObject:dictionary];
    }
    [PHRAppDelegate showLoading];
    [[PHRClient instance] requestSynchronizeBodyMeasurement:listDictionarySample profileID: profileID uuid:udid andCompleted:^(id response) {
        [PHRAppDelegate hideLoading];
        self.AddCallBack(self.addContentType);
        [self dismissViewControllerAnimated:YES completion:nil];
    } error:^(NSString *error) {
        [PHRAppDelegate hideLoading];
#if DEBUG
        [NSUtils showMessage:error withTitle:APP_NAME];
#endif
    }];
}

- (void)requestUpdateBodyMeasurement {
  
    [[PHRClient instance] requestUpdateBodyMeasurement:self.model andCompleted:^(id response) {
        [PHRAppDelegate hideLoading];
        if (response) {
            BOOL status = [PHRClient getStatusFromResponse:response];
            if(status){
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                if (newDict) {
                    self.model = [BodyMeasurementModel initWithObj:newDict];
                    self.model.type  = self.addContentType;
                    self.AddCallBack(self.addContentType);
                }
                [self dismissViewControllerAnimated:YES completion:nil];
            } else {
                NSString* message = [PHRClient getMessageFromResponse:response];
                [NSUtils showMessage:kLocalizedString(message) withTitle:APP_NAME];
            }
        }
    } error:^(NSString *error) {
        [PHRAppDelegate hideLoading];
        
    }];
}

- (IBAction)onTapBtnSave:(id)sender {
    
    if (!self.modelID || [self.modelID isEqual: [NSNull null]]) {
        NSMutableArray* arraySample = [[NSMutableArray alloc] init];
        
        if (self.addContentType != BodyMeasurementTypeBodyFat) {
            if (valueHeight != 0) {
                [arraySample addObject:[self savePHRSamleValue:round(valueHeight * 10) / 10 type:BodyMeasurementTypeHeight date:dateTime]];
            }
            if (valueWeight != 0) {
                [arraySample addObject:[self savePHRSamleValue:round(valueWeight * 10) / 10 type:BodyMeasurementTypeWeight date:dateTime]];
            }
            if ([self.labelBMIValue.text doubleValue] != 0) {
                [arraySample addObject:[self savePHRSamleValue:[self.labelBMIValue.text doubleValue] type:BodyMeasurementTypeBMI date:dateTime]];
            }
        } else {
            if (valueHeight != 0) {
                [arraySample addObject:[self savePHRSamleValue:round(valueHeight) type:BodyMeasurementTypeBodyFat date:dateTime]];
            }
            if (valueWeight != 0) {
                [arraySample addObject:[self savePHRSamleValue:round(valueWeight * 100) / 100 type:BodyMeasurementTypeWeight date:dateTime]];
            }
        }
          NSString * UUID = [[UIDevice currentDevice] identifierForVendor].UUIDString;
        if (arraySample.count > 0){
            [self requestAddListBodyMeasurement:arraySample withProfileID:PHRAppStatus.currentStandard.profileId andUDID:UUID];
        }

    } else {
       
        // assign if not exist
        if (!self.model) {
            self.model = [[BodyMeasurementModel alloc] init];
        }
         self.model.bodyMeasurementID = self.modelID;
        if (self.addContentType == BodyMeasurementTypeHeight) {
            self.model.height = [NSString stringWithFormat:@"%.1f",valueWeight];
        } else if (self.addContentType == BodyMeasurementTypeWeight) {
            self.model.weight = [NSString stringWithFormat:@"%.1f",valueWeight];
            self.model.percentFat = @"0";
        } else if (self.addContentType == BodyMeasurementTypeBodyFat) {
          //  self.model.weight = [NSString stringWithFormat:@"%.1f",valueWeight];
            self.model.percentFat = [NSString stringWithFormat:@"%d",(int)roundf(valueWeight) ];
        } else if (self.addContentType == BodyMeasurementTypeBMI) {
            self.model.bmi = [NSString stringWithFormat:@"%.2f",valueWeight];
        }
        
        self.model.date  = [UIUtils stringUTCDate:dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT];
        self.model.type  = self.addContentType;
        self.model.bodyMeasurementID = self.modelID;
        [PHRAppDelegate showLoading];
        [self requestUpdateBodyMeasurement];
    }
}

@end
