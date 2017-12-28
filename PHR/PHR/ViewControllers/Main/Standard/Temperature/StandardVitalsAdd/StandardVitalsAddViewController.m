//
//  StandardVitalsAddViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/15/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "StandardVitalsAddViewController.h"
#import "PHRChartUtils.h"
#import "TemperaturePhysiologyModel.h"

#define SLIDER_TAG 1
#define SLIDER_HIGH_PRESSURE_TAG 2

@interface StandardVitalsAddViewController (){
    NSString* vitalType;
    double value;
    double valueHighBloodPressure;
    NSDate *dateTime;
}

@end

@implementation StandardVitalsAddViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self initData];
    [self setupView];
    [self requestDetailIfNeeded];
}

- (void) initData {
    value = 0;
    dateTime = [NSDate date];
    if(self.addContentType == PHRChartTemperature){
        vitalType = @"01";
    }else if(self.addContentType == PHRChartBloodPressure){
        vitalType = @"04";
    }else if(self.addContentType == PHRChartHeartRate){
        vitalType = @"02";
    }else if(self.addContentType == PHRChartPrespiratory){
        vitalType = @"03";
    }
}

- (void)initView {
    self.view.backgroundColor = [UIColor clearColor];
    self.viewSave.backgroundColor = PHR_COLOR_VITALS_MAIN_COLOR;
    [self setupNavigationBarTitle:kLocalizedString(KTitleTemperature) iconLeft:@"backMenuBar" iconRight:nil iconMiddle:nil isDismissView:true colorLeft:nil colorRight:nil];
    [self.imageViewBackground setImage:[self.imageBackground applyLowLightEffect]];
    [self.viewOpacity setBackgroundColor:PHR_COLOR_VITALS_OVERLAY];

    [self.labelSave setText:kLocalizedString(kSave)];
    if (![PHRAppStatus checkCurrentStandardActive] || (self.model && self.model != [NSNull class])) {
        [self.viewSave setHidden:YES];
        self.constraintSliderAndSave.constant = 0 - self.viewSave.bounds.size.height;
    }
    if (self.addContentType == PHRChartBloodPressure){
        self.constraintHeightHighPressure.constant = 120;
    } else {
        self.constraintHeightHighPressure.constant = 0;
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
    [self initTabbarDuration];
    [self initSlider];
    [self initView];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
}

- (void)initTabbarDuration {
    self.tabbarDuration.delegate = self;
    [self.tabbarDuration initContentWhiteTransperent:@[kLocalizedString(kDottedTemperature), kLocalizedString(kDottedBloodPressure), kLocalizedString(kDottedHeartRate), kLocalizedString(kDottedRespiratory)] colorSelected:PHR_COLOR_VITALS_MAIN_COLOR andUnselectedColor:PHR_COLOR_TABBAR_DURATION_UNSELECTED textFont:[FontUtils aileronLightWithSize:14.0] selectedFont:[FontUtils aileronBoldWithSize:14.0]];
    self.tabbarDuration.selectedIndex = self.addContentType;
}

- (void)initSlider {
    if (self.addContentType == PHRChartTemperature) {
        [self.slider initialize:self andAddTypeName:HKQuantityTypeIdentifierBodyTemperature];
    } else if (self.addContentType == PHRChartBloodPressure){
        [self.slider initialize:self andAddTypeName:HKQuantityTypeIdentifierBloodPressureDiastolic];
    } else if (self.addContentType == PHRChartHeartRate){
        [self.slider initialize:self andAddTypeName:HKQuantityTypeIdentifierHeartRate];
    }  else if (self.addContentType == PHRChartPrespiratory){
        [self.slider initialize:self andAddTypeName:HKQuantityTypeIdentifierRespiratoryRate];
    }
    [self.sliderHighPressure initialize:self andAddTypeName:HKQuantityTypeIdentifierBloodPressureSystolic];
    self.slider.tag = SLIDER_TAG;
    self.sliderHighPressure.tag = SLIDER_HIGH_PRESSURE_TAG;
}

- (void)requestDetailIfNeeded {
    if (self.model && self.model != [NSNull class]) {
        [self fillDataToView:self.model];
        return;
    }
    if (self.modelID && self.modelID != [NSNull class]) {
        [self.tabbarDuration setEnabled:NO];
        __weak __typeof(self) weakSelf = self;
        [[PHRClient instance] requestDetailTemperatureWithId:self.modelID type:vitalType andCompletion:^(id response) {
            [PHRAppDelegate hideLoading];
            if (response) {
                BOOL status = [PHRClient getStatusFromResponse:response];
                if (!status) {
                    return;
                }
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                if (newDict) {
                    self.model = [TemperaturePhysiologyModel initWithObj:newDict];
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

- (void)scrollToDefaultValue {
    [self.sliderHighPressure scrollToPosition:self.defaultValueHigh];
    [self.slider scrollToPosition:self.defaultValue];
}

- (void)fillDataToView:(TemperaturePhysiologyModel*)temperatureModel {
    [self.slider updateTime:[UIUtils dateFromServerTimeString:temperatureModel.date]];
    self.modelID = temperatureModel.TemperaturePhysiologyID;
    
    if (self.addContentType == PHRChartTemperature) {
        [self.slider scrollToPosition:[temperatureModel.temperature floatValue]];
    } else if (self.addContentType == PHRChartBloodPressure) {
        [self.slider scrollToPosition:[temperatureModel.lowBloodPressure floatValue]];
        [self.sliderHighPressure scrollToPosition:[temperatureModel.highBloodPressure floatValue]];
    } else if (self.addContentType == PHRChartHeartRate) {
        [self.slider scrollToPosition:[temperatureModel.heartRate floatValue]];
    } else if (self.addContentType == PHRChartPrespiratory) {
        [self.slider scrollToPosition:[temperatureModel.respiratory floatValue]];
    }
}

// Save PHRSample to DB
- (void)savePHRSamleValue:(double)sampleValue type:(NSInteger)type date:(NSDate*)date {
    PHRSample *sample = [[PHRSample alloc] init];
    if (self.addContentType == PHRChartBloodPressure) {
        sample.value = sampleValue;
        sample.value2 = valueHighBloodPressure;
    } else {
        sample.value = sampleValue;
    }
    sample.profile_id = PHRAppStatus.masterProfileId;
    sample.type = [PHRSample healthkitTypeFromType:type fromScreen:StandardHomeTypeTemprature];
    sample.record_date = date;
    sample.source_bundle = [PHRSample bundle];
    sample.synced = 1;
    [[StorageManager instance] savePHRSampleManual:sample];
}

// Save PHRSample to DB
- (void)savePHRSamleValueForBloodPressure:(double)value type:(NSInteger)type date:(NSDate*)date{
    PHRSample *sample = [[PHRSample alloc] init];
    
    
    sample.profile_id = PHRAppStatus.masterProfileId;
    sample.type = [PHRSample healthkitTypeFromType:type fromScreen:StandardHomeTypeTemprature];
    sample.record_date = date;
    sample.source_bundle = [PHRSample bundle];
    sample.synced = 1;
    [[StorageManager instance] savePHRSampleManual:sample];
}
- (void)requestAddNewVital {

    [[PHRClient instance] requestAddNewTemperaturePhysiology:self.model completed:^(id response){
        [PHRAppDelegate hideLoading];
        if (response) {
            BOOL status = [PHRClient getStatusFromResponse:response];
            if(status){
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                if (newDict) {
                    self.model = [TemperaturePhysiologyModel initWithObj:newDict];
                    self.model.type  = self.addContentType;
                    self.self.addCallBack(self.addContentType);
                }
            } else {
                NSString* message = [PHRClient getMessageFromResponse:response];
                [NSUtils showMessage:kLocalizedString(message) withTitle:APP_NAME];
            }
            [self dismissViewControllerAnimated:YES completion:nil];
        }
        
    } error:^(NSString *error){
        [PHRAppDelegate hideLoading];
        [NSUtils showMessage:error withTitle:APP_NAME];
    }];
}

- (void)requestUpdateVitals {
    [[PHRClient instance] requestUpdateTemperature:self.model andCompleted:^(id response) {
        [PHRAppDelegate hideLoading];
        if (response) {
            BOOL status = [PHRClient getStatusFromResponse:response];
            if(status){
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                if (newDict) {
                    self.model = [TemperaturePhysiologyModel initWithObj:newDict];
                    self.model.type  = self.addContentType;
                    self.addCallBack(self.addContentType);
                }
                
            } else {
                NSString* message = [PHRClient getMessageFromResponse:response];
                [NSUtils showMessage:kLocalizedString(message) withTitle:APP_NAME];
            }
            [self dismissViewControllerAnimated:YES completion:nil];
        }
    } error:^(NSString *error) {
        [PHRAppDelegate hideLoading];
        
    }];
}

#pragma mark - MDTABBAR delegate
- (void)tabBar:(MDTabBar *)tabBar didChangeSelectedIndex:(NSUInteger)selectedIndex {
    if (tabBar.tag == MDTabBarTagTypeFourButtonNoBorder) {
        self.addContentType = selectedIndex;
        [self.slider resetView:[PHRChartUtils getChartType:StandardHomeTypeTemprature andIndex:self.addContentType]];
        if (selectedIndex == PHRChartBloodPressure){
            self.constraintHeightHighPressure.constant = 120;
        } else {
            self.constraintHeightHighPressure.constant = 0;
        }
    }
}

- (void) scrollViewScroll:(PHRSlider*)slider value:(double) valueScroll {
    if (slider.tag == SLIDER_HIGH_PRESSURE_TAG) {
        valueHighBloodPressure = valueScroll;
    } else {
        value = valueScroll;
    }
   
}

-(void)dateTimeChanged:(NSDate *)date {
    dateTime = date;
}

- (IBAction)onTapBtnSave:(id)sender {
    
    // assign if not exist
    if (!self.model) {
        self.model = [[TemperaturePhysiologyModel alloc] init];
    }
    
    if (self.addContentType == PHRChartTemperature) {
        self.model.temperature = [NSString stringWithFormat:@"%.1f",value];
    } else if (self.addContentType == PHRChartBloodPressure) {
        self.model.highBloodPressure = [NSString stringWithFormat:@"%.0f",valueHighBloodPressure];
        self.model.lowBloodPressure = [NSString stringWithFormat:@"%.0f",value];
    } else if (self.addContentType == PHRChartHeartRate) {
        self.model.heartRate = [NSString stringWithFormat:@"%.0f",value];
    } else if (self.addContentType == PHRChartPrespiratory) {
        self.model.respiratory = [NSString stringWithFormat:@"%.0f",value];
    }
    
    self.model.date  = [UIUtils stringUTCDate:dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT];
    self.model.type  = self.addContentType;
    
    [PHRAppDelegate showLoading];
    if (!self.modelID || [self.modelID isEqual: [NSNull null]]) {
        [self requestAddNewVital];
        // SAVE TO INTERNAL DB
        if ([PHRAppStatus checkCurrentStandardIsMaster]) {
            if (self.addContentType == PHRChartTemperature) {
                [self savePHRSamleValue:round(value * 10) / 10 type:self.addContentType date:dateTime];
            } else {
                [self savePHRSamleValue:value type:self.addContentType date:dateTime];
            }
            
        }
    } else {
        self.model.TemperaturePhysiologyID = self.modelID;
        [self requestUpdateVitals];
    }
}
@end
