//
//  StandardFitnessAddViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/15/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "StandardFitnessAddViewController.h"
#import "PHRChartUtils.h"

@interface StandardFitnessAddViewController (){
    NSString* fitnessType;
    double value;
    NSDate *dateTime;
}

@end

@implementation StandardFitnessAddViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self initData];
    [self setupView];
    [self requestDetailIfNeeded];
}

- (void) initData {
    value = 0;
    dateTime = [NSDate date];
    fitnessType = [NSString stringWithFormat: @"0%d",(int)self.addContentType + 1];
}

- (void)initView {
    self.view.backgroundColor = [UIColor clearColor];
    [self setupNavigationBarTitle:kLocalizedString(kTitleFitness) iconLeft:@"backMenuBar" iconRight:nil iconMiddle:nil isDismissView:true colorLeft:nil colorRight:nil];
    [self.imageViewBackground setImage:[self.imageBackground applyLowLightEffect]];
    [self.viewOpacity setBackgroundColor:PHR_COLOR_FITNESS_OVERLAY];
    [self.viewSave setBackgroundColor:PHR_COLOR_FITNESS_MAIN_COLOR];
    [self.labelSave setText:kLocalizedString(kSave)];
    if (![PHRAppStatus checkCurrentStandardActive] || (self.model && self.model != [NSNull class]))  {
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
    [self initTabbarDuration];
    [self initSlider];
    [self initView];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
}

- (void)initTabbarDuration {
    self.tabbarDuration.delegate = self;
    [self.tabbarDuration initContentWhiteTransperent:@[kLocalizedString(kDottedStepCount), kLocalizedString(kDottedWalkingRunDistance)] colorSelected:PHR_COLOR_FITNESS_MAIN_COLOR andUnselectedColor:PHR_COLOR_TABBAR_DURATION_UNSELECTED textFont:[FontUtils aileronLightWithSize:14.0] selectedFont:[FontUtils aileronBoldWithSize:14.0]];
    self.tabbarDuration.selectedIndex = self.addContentType;
}

- (void)initSlider {
    if (self.addContentType == ChartFitnessTypeSteps) {
        [self.slider initialize:self andAddTypeName:HKQuantityTypeIdentifierStepCount];
    } else {
        [self.slider initialize:self andAddTypeName:HKQuantityTypeIdentifierDistanceWalkingRunning];
    }
}

- (void)requestDetailIfNeeded {
    if (self.model && self.model != [NSNull class]) {
        [self fillDataToView:self.model];
        return;
    }
    if (self.modelID && self.modelID != [NSNull class]) {
        [self.tabbarDuration setEnabled:NO];
        __weak __typeof(self) weakSelf = self;
        [[PHRClient instance] requestDetailFitnessWithId:self.modelID fitnessType:fitnessType andCompletion:^(id response) {
            [PHRAppDelegate hideLoading];
            if (response) {
                BOOL status = [PHRClient getStatusFromResponse:response];
                if (!status) {
                    return;
                }
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                if (newDict) {
                    self.model  = [FitnessModel initWithObj:newDict];
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
    [self.slider scrollToPosition:self.defaultValue];
}

- (void)fillDataToView:(FitnessModel*)fitnessModel {
    [self.slider updateTime:[UIUtils dateFromServerTimeString:fitnessModel.date]];
    self.modelID = fitnessModel.fitnessID;
    
    if (self.addContentType == ChartFitnessTypeSteps) {
        [self.slider scrollToPosition:[fitnessModel.step floatValue]];
    } else if (self.addContentType == ChartFitnessTypeWalkRun) {
        [self.slider scrollToPosition:[fitnessModel.walkrun floatValue]];
    }
}

// Save PHRSample to DB
- (void)savePHRSamleValue:(double)sampleValue type:(NSInteger)type date:(NSDate*)date {
    PHRSample *sample = [[PHRSample alloc] init];
    sample.value = sampleValue;
    sample.profile_id = PHRAppStatus.masterProfileId;
    sample.type = [PHRSample healthkitTypeFromType:type fromScreen:StandardHomeTypeFitness];
    sample.record_date = date;
    sample.source_bundle = [PHRSample bundle];
    sample.synced = 1;
    [[StorageManager instance] savePHRSampleManual:sample];
}

- (void)requestAddNewFitness {
    [[PHRClient instance] requestAddNewFitness:self.model completed:^(id response){
        [PHRAppDelegate hideLoading];
        if (response) {
            BOOL status = [PHRClient getStatusFromResponse:response];
            if(status){
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                if (newDict) {
                    self.model = [FitnessModel initWithObj:newDict];
                    self.model.type  = self.addContentType;
                    self.addCallBack(self.addContentType);
                }
                
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

- (void)requestUpdateFitness {
    [[PHRClient instance] requestEditFitness:self.model completed:^(id response) {
        [PHRAppDelegate hideLoading];
        if (response) {
            BOOL status = [PHRClient getStatusFromResponse:response];
            if(status){
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                if (newDict) {
                    self.model = [FitnessModel initWithObj:newDict];
                    self.model.type  = self.addContentType;
                    self.addCallBack(self.addContentType);
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

#pragma mark - MDTABBAR delegate
- (void)tabBar:(MDTabBar *)tabBar didChangeSelectedIndex:(NSUInteger)selectedIndex {
    if (tabBar.tag == MDTabBarTagTypeFourButtonNoBorder) {
        self.addContentType = selectedIndex;
        [self.slider resetView:[PHRChartUtils getChartType:StandardHomeTypeFitness andIndex:self.addContentType]];
    }
}

- (void) scrollViewScroll:(PHRSlider*)slider value:(double) valueScroll {
    value = valueScroll;
}

-(void)dateTimeChanged:(NSDate *)date {
    dateTime = date;
    NSLog(@"dateTime: %@",dateTime);
}

- (IBAction)onTapBtnSave:(id)sender {
    
    // assign if not exist
    if (!self.model) {
        self.model = [[FitnessModel alloc] init];
    }
    
    if (self.addContentType == ChartFitnessTypeSteps) {
        self.model.step = [NSString stringWithFormat:@"%.0f",value];
    } else if (self.addContentType == ChartFitnessTypeWalkRun) {
        self.model.walkrun = [NSString stringWithFormat:@"%.2f",value];
    }
    
    self.model.date  = [UIUtils stringUTCDate:dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT];
    self.model.type  = self.addContentType;
    
    [PHRAppDelegate showLoading];
    if (!self.modelID || [self.modelID isEqual: [NSNull null]]) {
        [self requestAddNewFitness];
        // SAVE TO INTERNAL DB
        if ([PHRAppStatus checkCurrentStandardIsMaster]) {
            [self savePHRSamleValue:value type:self.addContentType date:dateTime];
        }
    } else {
        self.model.fitnessID = self.modelID;
        [self requestUpdateFitness];
    }
}
@end
