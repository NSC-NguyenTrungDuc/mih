//
//  StandardFoodAddViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/16/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BabyMilkAddViewController.h"

#define SLIDER_CAL 0
#define SLIDER_MINUTE 1
#define BABY_MOTHER_MILK_METHOD     @"0"
#define BABY_BOTTLE_MILK_METHOD     @"1"

@interface BabyMilkAddViewController (){
    double value;
    double valueMinute;
    NSDate *dateTime;
}
@end

@implementation BabyMilkAddViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self initData];
    [self setupView];
    [self requestDetailMilkIfNeeded];
}

- (void) initData {
    value = 0;
    dateTime = [NSDate date];
}

- (void)initView {
    self.view.backgroundColor = [UIColor clearColor];
    [self setupNavigationBarTitle:kLocalizedString(kBabyTitleMilk) iconLeft:@"backMenuBar" iconRight:nil iconMiddle:nil isDismissView:true colorLeft:nil colorRight:nil];
    [self.imageViewBackground setImage:[self.imageBackground applyLowLightEffect]];
    [self.viewOpacity setBackgroundColor:PHR_COLOR_BABY_MILK_OVERLAY];
    
    [self.labelSave setText:kLocalizedString(kSave)];
//    if (![PHRAppStatus checkCurrentBabyActive] || self.isEdit) {
    if (![PHRAppStatus checkCurrentBabyActive]) {
        [self.viewSave setHidden:YES];
        self.constraintSliderAndSave.constant = 0 - self.viewSave.bounds.size.height;
    }
    
    if (self.addContentType == PHRGroupTypeMotherMilk) {
        self.constraintHeightTextField.constant = 0;
        self.tfMilkType.placeholder = @"";
    } else {
        self.constraintHeightTextField.constant = 40;
        self.tfMilkType.placeholder = kLocalizedString(kMilkType);
    }
    self.tfMilkType.backgroundColor = [UIColor clearColor];
    
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
    [self.tabbarDuration initContentWhiteTransperent:@[kLocalizedString(kTitleMotherMilk), kLocalizedString(kTitleBottleMilk)] colorSelected:PHR_COLOR_BABY_MILK_MAIN_COLOR andUnselectedColor:PHR_COLOR_TABBAR_DURATION_UNSELECTED textFont:[FontUtils aileronLightWithSize:14.0] selectedFont:[FontUtils aileronBoldWithSize:14.0]];
    self.tabbarDuration.selectedIndex = self.addContentType;
}

- (void)initSlider {
    [self.slider initialize:self andAddTypeName:PHR_BABY_MILK_TYPE];
    
    if (self.addContentType == PHRGroupTypeMotherMilk) {
        [self.sliderTime initialize:self andAddTypeName:PHR_BABY_MILK_TIME];
    } else if (self.addContentType == PHRGroupTypeBottleMilk){
        [self.sliderTime initialize:self andAddTypeName:PHR_BABY_MILK_VOLUME];
    }
    
    self.slider.tag = SLIDER_CAL;
    self.sliderTime.tag = SLIDER_MINUTE;
}

- (void)requestDetailMilkIfNeeded {
    if (self.model && self.model != [NSNull class]) {
        [self.tabbarDuration setEnabled:NO];
        [self fillDataToView:self.model];
    } else {
        [self scrollToDefaultValue];
    }
}

- (void)scrollToDefaultValue {
    [self.slider scrollToPosition:self.defaultValue];
     [self.sliderTime scrollToPosition:self.defaultValueTime];
}

- (void)fillDataToView:(BabyMilkModel*)milkItem {
    [self.slider updateTime:[UIUtils dateFromServerTimeString:milkItem.time_drink_milk]];
    self.modelID = milkItem.id;
    [self.slider scrollToPosition: [milkItem.calories floatValue]];
    if (self.addContentType == PHRGroupTypeMotherMilk) {
        [self.sliderTime scrollToPosition: [milkItem.breast_time intValue]];
    } else {
        [self.sliderTime scrollToPosition: [milkItem.bottle_milk_volume intValue]];
        self.tfMilkType.text = milkItem.milk_type;
    }
}

- (void)requestAddNewBabyMilk {
    BabyMilkModel *objBabyMilk = [[BabyMilkModel alloc] init];
    objBabyMilk.time_drink_milk = [UIUtils stringUTCDate:dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT];
    objBabyMilk.alert = @"0";
    objBabyMilk.calories = [NSString stringWithFormat:@"%.2f",value];
    
    
    if (self.addContentType == PHRGroupTypeMotherMilk) {
        
        objBabyMilk.breast_time = [NSString stringWithFormat:@"%.0f",valueMinute];
        objBabyMilk.drink_method = BABY_MOTHER_MILK_METHOD;
        
        [PHRAppDelegate showLoading];
        [[PHRClient instance] requestAddNewBabyMilkWithObj:objBabyMilk andCompleted:^(id parmas) {
            [PHRAppDelegate hideLoading];
            NSString *newMilkId = parmas[KEY_Content][KEY_Id];
            objBabyMilk.id = newMilkId;
             self.AddCallBack(self.addContentType);
            [[NSNotificationCenter defaultCenter] postNotificationName:PHRNotificationAddNewData object:objBabyMilk];
            [self dismissViewControllerAnimated:YES completion:nil];
        } error:^(NSString *error) {
            [PHRAppDelegate hideLoading];
            [NSUtils showAlertWithTitle:[NSString stringWithFormat:@"%@", error.description] message:kLocalizedString(kTitleAlertError)];
        }];
    } else {
        if ([self.tfMilkType.text isEqualToString:@""]) {
            [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kMilkMissType)];
            return;
        }
        if (self.tfMilkType.text.length > 10) {
            [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kTextInputLong)];
            return;
        }
        objBabyMilk.bottle_milk_volume = [NSString stringWithFormat:@"%.0f",valueMinute];
        objBabyMilk.drink_method = BABY_BOTTLE_MILK_METHOD;
        objBabyMilk.milk_type = self.tfMilkType.text;
        
        [PHRAppDelegate showLoading];
        [[PHRClient instance] requestAddNewBottleMilk:objBabyMilk andCompleted:^(id parmas) {
            [PHRAppDelegate hideLoading];
            NSString *newMilkId = parmas[KEY_Content][KEY_Id];
            objBabyMilk.id = newMilkId;
             self.AddCallBack(self.addContentType);
            [[NSNotificationCenter defaultCenter] postNotificationName:PHRNotificationAddNewData object:objBabyMilk];
            [self dismissViewControllerAnimated:YES completion:nil];
        } error:^(NSString *error) {
            [PHRAppDelegate hideLoading];
            [NSUtils showAlertWithTitle:[NSString stringWithFormat:@"%@", error.description] message:kLocalizedString(kTitleAlertError)];
        }];
    }

}

//Update BabyMilk
- (void)requestUpdateBabyMilk {
    NSLog(@"Update baby milk");
    
    if (self.addContentType == PHRGroupTypeMotherMilk) {
        
        
        [PHRAppDelegate showLoading];
        [[PHRClient instance] requestUpdateMilk:self.model andCompleted:^(id parmas) {
            [PHRAppDelegate hideLoading];
            //objBabyMilk.id = newMilkId;
            self.AddCallBack(self.addContentType);
            [[NSNotificationCenter defaultCenter] postNotificationName:PHRNotificationAddNewData object:self.model];
            [self dismissViewControllerAnimated:YES completion:nil];
        } error:^(NSString *error) {
            [PHRAppDelegate hideLoading];
            [NSUtils showAlertWithTitle:[NSString stringWithFormat:@"%@", error.description] message:kLocalizedString(kTitleAlertError)];
        }];
    }
    else {
        if ([self.tfMilkType.text isEqualToString:@""]) {
            [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kMilkMissType)];
            return;
        }
        if (self.tfMilkType.text.length > 10) {
            [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kTextInputLong)];
            return;
        }
        
        [PHRAppDelegate showLoading];
        [[PHRClient instance] requestUpdateMilk:self.model andCompleted:^(id parmas) {
            [PHRAppDelegate hideLoading];
            self.AddCallBack(self.addContentType);
            [[NSNotificationCenter defaultCenter] postNotificationName:PHRNotificationAddNewData object:self.model];
            [self dismissViewControllerAnimated:YES completion:nil];
        } error:^(NSString *error) {
            [PHRAppDelegate hideLoading];
            [NSUtils showAlertWithTitle:[NSString stringWithFormat:@"%@", error.description] message:kLocalizedString(kTitleAlertError)];
        }];
    }
    
}

- (void)requestUpdateGrowth {
    
}

#pragma mark - MDTABBAR delegate
- (void)tabBar:(MDTabBar *)tabBar didChangeSelectedIndex:(NSUInteger)selectedIndex {
    if (tabBar.tag == MDTabBarTagTypeFourButtonNoBorder) {
        self.addContentType = selectedIndex;
        if (self.addContentType == PHRGroupTypeMotherMilk) {
            [self.sliderTime resetView:PHR_BABY_MILK_TIME];
        } else if (self.addContentType == PHRGroupTypeBottleMilk){
            [self.sliderTime resetView:PHR_BABY_MILK_VOLUME];
        }
        if (self.addContentType == PHRGroupTypeMotherMilk) {
            self.constraintHeightTextField.constant = 0;
            self.tfMilkType.placeholder = @"";
        } else {
            self.constraintHeightTextField.constant = 40;
            self.tfMilkType.placeholder = kLocalizedString(kMilkType);
        }
    }
}

- (void) scrollViewScroll:(PHRSlider*)slider value:(double) valueScroll {
    if (slider.tag == SLIDER_CAL) {
        value = valueScroll;
    }
    else if (slider.tag == SLIDER_MINUTE) {
        valueMinute = valueScroll;
    }
}

-(void)dateTimeChanged:(NSDate *)date {
    dateTime = date;
}

- (IBAction)onTapBtnSave:(id)sender {
    // assign if not exist
    if (!self.model) {
        // add new
//        self.model = [[BabyMilkModel alloc] init];
//        self.model.time_drink_milk = [UIUtils stringUTCDate:dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT];
//        self.model.calories = [NSString stringWithFormat:@"%.2f",value];
//        self.model.alert = @"0";
      
        if (!self.modelID || [self.modelID isEqual: [NSNull null]]) {
            [self requestAddNewBabyMilk];
        }
    }
    else{
    
        //Update
        self.model.time_drink_milk = [UIUtils stringUTCDate:dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT];
        self.model.calories = [NSString stringWithFormat:@"%.2f",value];
        self.model.breast_time = [NSString stringWithFormat:@"%.0f",valueMinute];
        //TODO call api
        [self requestUpdateBabyMilk];
    }
    

}

@end
