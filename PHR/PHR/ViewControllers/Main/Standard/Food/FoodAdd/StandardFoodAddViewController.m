//
//  StandardFoodAddViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/16/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "StandardFoodAddViewController.h"

@interface StandardFoodAddViewController (){
    NSString* foodType;
    double value;
    NSDate *dateTime;
}


@end

@implementation StandardFoodAddViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self initData];
    [self setupView];
    [self requestDetailFoodIfNeeded];
}

- (void) initData {
    value = 0;
    dateTime = [NSDate date];
    foodType = [NSString stringWithFormat: @"0%d", (int)self.addContentType + 1];
}

- (void)initView {
    self.view.backgroundColor = [UIColor clearColor];
    [self setupNavigationBarTitle:kLocalizedString(kTitleFood) iconLeft:@"backMenuBar" iconRight:nil iconMiddle:nil isDismissView:true colorLeft:nil colorRight:nil];
    [self.imageViewBackground setImage:[self.imageBackground applyLowLightEffect]];
    [self.viewOpacity setBackgroundColor:PHR_COLOR_FOOD_OVERLAY];
    
    [self.labelSave setText:kLocalizedString(kSave)];
    if (![PHRAppStatus checkCurrentStandardActive] || (self.foodItem && self.foodItem != [NSNull class])) {
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
    [self.tabbarDuration initContentWhiteTransperent:@[kLocalizedString(kDottedCalories), kLocalizedString(kDottedCarbohydrate),kLocalizedString(kDottedTotalFat)] colorSelected:PHR_COLOR_FOOD_MAIN_COLOR andUnselectedColor:PHR_COLOR_TABBAR_DURATION_UNSELECTED textFont:[FontUtils aileronLightWithSize:14.0] selectedFont:[FontUtils aileronBoldWithSize:14.0]];
    self.tabbarDuration.selectedIndex = self.addContentType;
}

- (void)initSlider {
    if (self.addContentType == FoodTypeCalories) {
        [self.slider initialize:self andAddTypeName:HKQuantityTypeIdentifierDietaryEnergyConsumed];
    } else if (self.addContentType == FoodTypeCarbohydrates){
        [self.slider initialize:self andAddTypeName:HKQuantityTypeIdentifierDietaryCarbohydrates];
    } else {
        [self.slider initialize:self andAddTypeName:HKQuantityTypeIdentifierDietaryFatTotal];
    }
}

- (void)requestDetailFoodIfNeeded {
    if (self.foodItem && self.foodItem != [NSNull class]) {
        [self fillDataToView:self.foodItem];
        return;
    }
    if (self.modelID && self.modelID != [NSNull class]) {
        [self.tabbarDuration setEnabled:NO];
        __weak __typeof(self) weakSelf = self;
        [[PHRClient instance] requestDetailFoodWithId:self.modelID healthType:foodType andCompletion:^(id response) {
            [PHRAppDelegate hideLoading];
            if (response) {
                BOOL status = [PHRClient getStatusFromResponse:response];
                if (!status) {
                    return;
                }
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                if (newDict) {
                    self.foodItem = [FoodItem initWithObj:newDict];
                    self.foodItem.type  = self.addContentType;
                }
            }
            [weakSelf fillDataToView:self.foodItem];
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

- (void)fillDataToView:(FoodItem*)foodItem {
    [self.slider updateTime:[UIUtils dateFromServerTimeString:foodItem.date]];
    self.modelID = foodItem.foodID;
    if (self.addContentType == ChartFoodTypeCalories) {
         [self.slider scrollToPosition:[foodItem.calories floatValue]];
    } else if (self.addContentType == ChartFoodTypeCarbohydrates) {
        [self.slider scrollToPosition:[foodItem.carbohydrates floatValue]];
    } else if(self.addContentType == ChartFoodTypeTotalFat) {
         [self.slider scrollToPosition:[foodItem.totalFat floatValue]];
    }

}

// Save PHRSample to DB
- (void)savePHRSamleValue:(double)sampleValue type:(NSInteger)type date:(NSDate*)date{
    PHRSample *sample = [[PHRSample alloc] init];
    sample.value = sampleValue;
    sample.profile_id = PHRAppStatus.masterProfileId;
    sample.type = [PHRSample healthkitTypeFromType:type fromScreen:StandardHomeTypeFood];
    sample.record_date = date;
    sample.source_bundle = [PHRSample bundle];
    sample.synced = 1;
    [[StorageManager instance] savePHRSampleManual:sample];
}

- (void)requestAddNewFood {
    [[PHRClient instance] requestAddNewFood:self.foodItem completed:^(id response){
        [PHRAppDelegate hideLoading];
        if (response) {
            BOOL status = [PHRClient getStatusFromResponse:response];
            if(status){
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                if (newDict) {
                    self.foodItem = [FoodItem initWithObj:newDict];
                    self.foodItem.type  = self.addContentType;
                    self.AddCallBack(self.addContentType);
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

- (void)requestUpdateFood {
    [[PHRClient instance] requestUpdateFood:self.foodItem andCompleted:^(id response) {
        [PHRAppDelegate hideLoading];
        if (response) {
            BOOL status = [PHRClient getStatusFromResponse:response];
            if(status){
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                if (newDict) {
                    self.foodItem = [FoodItem initWithObj:newDict];
                    self.foodItem.type  = self.addContentType;
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

#pragma mark - MDTABBAR delegate
- (void)tabBar:(MDTabBar *)tabBar didChangeSelectedIndex:(NSUInteger)selectedIndex {
    if (tabBar.tag == MDTabBarTagTypeFourButtonNoBorder) {
        self.addContentType = selectedIndex;
        [self.slider resetView:[PHRChartUtils getChartType:StandardHomeTypeFood andIndex:self.addContentType]];
    }
}

- (void) scrollViewScroll:(PHRSlider*)slider value:(double) valueScroll {
    value = valueScroll;
}

-(void)dateTimeChanged:(NSDate *)date {
    dateTime = date;
}

- (IBAction)onTapBtnSave:(id)sender {
    // assign if not exist
    if (!self.foodItem) {
        self.foodItem = [[FoodItem alloc] init];
    }
    
    if (self.addContentType == FoodTypeCalories) {
        self.foodItem.calories = [NSString stringWithFormat:@"%.0f",value];
    } else if (self.addContentType == FoodTypeCarbohydrates) {
        self.foodItem.carbohydrates = [NSString stringWithFormat:@"%.0f",value];
    } else if(self.addContentType == ChartFoodTypeTotalFat) {
        self.foodItem.totalFat = [NSString stringWithFormat:@"%.0f",value];
    }
    self.foodItem.date  = [UIUtils stringUTCDate:dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT];
    self.foodItem.note  = @"";
    self.foodItem.type  = self.addContentType;
    
    [PHRAppDelegate showLoading];
    if (!self.modelID || [self.modelID isEqual: [NSNull null]]) {
        [self requestAddNewFood];
        // SAVE TO INTERNAL DB
        if ([PHRAppStatus checkCurrentStandardIsMaster]) {
            [self savePHRSamleValue:round(value) type:self.addContentType date:dateTime];
        }
    } else {
        self.foodItem.foodID = self.modelID;
        [self requestUpdateFood];
    }
}

@end
