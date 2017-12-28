//
//  BabyGrowthAddViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/16/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BabyGrowthAddViewController.h"

@interface BabyGrowthAddViewController (){
    NSString* babyGrowthType;
    double value;
    NSDate *dateTime;
}


@end

@implementation BabyGrowthAddViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self initData];
    [self setupView];
    [self requestDetailFoodIfNeeded];
}

- (void) initData {
    value = 0;
    dateTime = [NSDate date];
    babyGrowthType = [NSString stringWithFormat: @"0%d", (int)self.addContentType + 1];
}

- (void)initView {
    self.view.backgroundColor = [UIColor clearColor];
    [self setupNavigationBarTitle:kLocalizedString(kBabyTitleGrowth) iconLeft:@"backMenuBar" iconRight:nil iconMiddle:nil isDismissView:true colorLeft:nil colorRight:nil];
    [self.viewSave setBackgroundColor:PHR_COLOR_BABY_GROWTH_MAIN_COLOR];
    [self.imageViewBackground setImage:[self.imageBackground applyLowLightEffect]];
    [self.viewOpacity setBackgroundColor:PHR_COLOR_BABY_GROWTH_OVERLAY];
    
    [self.labelSave setText:kLocalizedString(kSave)];
    if (![PHRAppStatus checkCurrentBabyActive] || (self.model && self.model != [NSNull class])) {
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
    [self.tabbarDuration initContentWhiteTransperent:@[[NSString stringWithFormat:@"%@%@",@"᛫",kLocalizedString(kHeightUppercase)],[NSString stringWithFormat:@"%@%@",@"᛫",kLocalizedString(kWeightUppercase)]] colorSelected:PHR_COLOR_BABY_GROWTH_MAIN_COLOR andUnselectedColor:PHR_COLOR_TABBAR_DURATION_UNSELECTED textFont:[FontUtils aileronLightWithSize:14.0] selectedFont:[FontUtils aileronBoldWithSize:14.0]];
    self.tabbarDuration.selectedIndex = self.addContentType;
}

- (void)initSlider {
    if (self.addContentType == BabyGrowthHeight) {
        [self.slider initialize:self andAddTypeName:PHR_BABY_HK_QUANTITY_HEIGHT];
    } else if (self.addContentType == BabyGrowthWeight){
        [self.slider initialize:self andAddTypeName:PHR_BABY_HK_QUANTITY_BODY_MASS];
    }
}

- (void)requestDetailFoodIfNeeded {
    if (self.model && self.model != [NSNull class]) {
        [self fillDataToView:self.model];
        return;
    }
    if (self.modelID && self.modelID != [NSNull class]) {
        __weak __typeof(self) weakSelf = self;
        [[PHRClient instance] requestDetailBabyGrowthWithId:self.modelID babyGrowthType:babyGrowthType andCompletion:^(id response) {
            [PHRAppDelegate hideLoading];
            if (response) {
                BOOL status = [PHRClient getStatusFromResponse:response];
                if (!status) {
                    return;
                }
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                if (newDict) {
                    self.model = [BabyGrowth initBabyGrowthWithObj:newDict];
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

- (void)fillDataToView:(BabyGrowth*)growthItem {
    [self.slider updateTime:[UIUtils dateFromServerTimeString:growthItem.dateTime]];
    self.modelID = growthItem.growthId;
    if (self.addContentType == BabyGrowthHeight) {
         [self.slider scrollToPosition:[growthItem.height floatValue]];
    } else if (self.addContentType == BabyGrowthWeight) {
        [self.slider scrollToPosition:[growthItem.weight floatValue]];
    }

}

- (void)scrollToDefaultValue {
    [self.slider scrollToPosition:self.defaultValue];
}

- (void)requestAddNewGrowth {
    [[PHRClient instance] requestAddNewBabyGrowth:self.model completed:^(id response){
        [PHRAppDelegate hideLoading];
        if (response) {
            BOOL status = [PHRClient getStatusFromResponse:response];
            if(status){
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                if (newDict) {
                    self.model = [BabyGrowth initBabyGrowthWithObj:newDict];
//                    NSString *newId = newDict[KEY_Content][KEY_Growth_ID];
//                    self.model.growthId = newId;
                    self.model.type  = self.addContentType;
                    self.AddCallBack(self.addContentType);
                    BabyGrowthModel *babyGrowthModel = [self.model getBabyGrowthModel];
                    [[NSNotificationCenter defaultCenter] postNotificationName:PHRNotificationAddNewData object:babyGrowthModel];
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

- (void)requestUpdateGrowth {
    [[PHRClient instance] requestUpdateBabyGrowth:self.model andCompleted:^(id response) {
        [PHRAppDelegate hideLoading];
        if (response) {
            BOOL status = [PHRClient getStatusFromResponse:response];
            if(status){
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                if (newDict) {
                    self.model = [BabyGrowth initBabyGrowthWithObj:newDict];
                    self.model.type  = self.addContentType;
                    self.AddCallBack(self.addContentType);
                    BabyGrowthModel *babyGrowthModel = [self.model getBabyGrowthModel];
                    [[NSNotificationCenter defaultCenter] postNotificationName:PHRNotificationEditData object:babyGrowthModel];
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
        if (self.addContentType == BabyGrowthHeight) {
            [self.slider resetView:PHR_BABY_HK_QUANTITY_HEIGHT];
        } else if (self.addContentType == BabyGrowthWeight){
            [self.slider resetView:PHR_BABY_HK_QUANTITY_BODY_MASS];
        }
//        [self.slider resetView:[PHRChartUtils getChartType:PHRBabyGroupTypeGrowth andIndex:self.addContentType]];
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
    if (!self.model) {
        self.model = [[BabyGrowth alloc] init];
    }
    
    if (self.addContentType == BabyGrowthHeight) {
        self.model.height = [NSString stringWithFormat:@"%.1f",value];
    } else if (self.addContentType == BabyGrowthWeight) {
        self.model.weight = [NSString stringWithFormat:@"%.1f",value];
    }
    self.model.dateTime  = [UIUtils stringUTCDate:dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT];
    self.model.doctorNote  = @"";
    self.model.parentNote  = @"";
    self.model.type  = self.addContentType;
    
    [PHRAppDelegate showLoading];
    if (!self.modelID || [self.modelID isEqual: [NSNull null]]) {
        [self requestAddNewGrowth];
  
    } else {
        self.model.growthId = self.modelID;
        [self requestUpdateGrowth];
    }
}

@end
