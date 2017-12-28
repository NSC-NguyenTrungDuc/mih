//
//  BabyFoodAddViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/16/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BabyFoodAddViewController.h"

@interface BabyFoodAddViewController (){
    double value;
    NSDate *dateTime;
}

@end

@implementation BabyFoodAddViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self initData];
    [self setupView];
    [self requestDetailFoodIfNeeded];
}

- (void) initData {
    value = 0;
    dateTime = [NSDate date];
}

- (void)initView {
    self.view.backgroundColor = [UIColor clearColor];
    [self setupNavigationBarTitle:kLocalizedString(kBabyTitleFood) iconLeft:@"backMenuBar" iconRight:nil iconMiddle:nil isDismissView:true colorLeft:nil colorRight:nil];
    [self.imageViewBackground setImage:[self.imageBackground applyLowLightEffect]];
    [self.viewOpacity setBackgroundColor:PHR_COLOR_BABY_FOOD_OVERLAY];
    
    [self.labelSave setText:kLocalizedString(kSave)];
    if (![PHRAppStatus checkCurrentBabyActive] || (self.foodItem && self.foodItem != [NSNull class])) {
        [self.viewSave setHidden:YES];
        self.constraintSliderAndSave.constant = 0 - self.viewSave.bounds.size.height;
    }
    
    self.textFieldFood.delegate = self;
    [self.labelMealType setText:kLocalizedString(kRiceGruel)];
  
    UIView *paddingView = [[UIView alloc] initWithFrame:CGRectMake(0, 0, 10, 10)];
    self.textFieldFood.leftView = paddingView;
    self.textFieldFood.leftViewMode = UITextFieldViewModeAlways;
    [self.textFieldFood setPlaceholder:kLocalizedString(kTitleFood)];
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
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
}


- (void)initSlider {
    [self.slider initialize:self andAddTypeName:PHR_BABY_FOOD_TYPE];
}

- (void)requestDetailFoodIfNeeded {
    if (self.foodItem && self.foodItem != [NSNull class]) {
        [self fillDataToView:self.foodItem];
        return;
    }
    if (self.modelID && self.modelID != [NSNull class]) {
        __weak __typeof(self) weakSelf = self;
        
        [[PHRClient instance] requestGetDetailBabyFoodsWithId:self.modelID completed:^(id response) {
            if (response) {
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                if (newDict) {
                    ChildrenFoodModel *model = [ChildrenFoodModel initWithObj:newDict];
                    [weakSelf fillDataToView:model];
                }
            }
        } error:^(NSString *error) {
            [NSUtils showMessage:[NSString stringWithFormat:@"%@", error.description] withTitle:kLocalizedString(kTitleAlertError)];
        }];

    }
    else {
        [self scrollToDefaultValue];
    }
}

- (void)fillDataToView:(ChildrenFoodModel*)foodItem {
    self.textFieldFood.text = foodItem.food;
    [self.slider updateTime:[UIUtils dateFromServerTimeString:foodItem.date]];
    self.modelID = foodItem.childrenFoodID;
    [self.slider scrollToPosition:[foodItem.kcal floatValue]];
    NSMutableAttributedString* mealType = [[NSMutableAttributedString alloc] initWithString:foodItem.mealType];
    [mealType addAttribute:NSUnderlineStyleAttributeName value:[NSNumber numberWithInteger:(NSUnderlinePatternDot|NSUnderlineStyleSingle)] range:NSMakeRange(0, [foodItem.mealType length])];
    [self.labelMealType setAttributedText:mealType];
}

- (void)requestAddNewFood {
    [[PHRClient instance] requestAddNewBabyFoodWithObj:self.foodItem andCompleted:^(id params) {
        NSString *newId = params[KEY_Content][KEY_Food_ID];
        self.AddCallBack();
        self.foodItem.childrenFoodID = newId;
        BabyFoodModel *model  = [self.foodItem getBabyFoodModel];
        [[NSNotificationCenter defaultCenter] postNotificationName:PHRNotificationAddNewData object:model];
        [PHRAppDelegate hideLoading];
        [self dismissViewControllerAnimated:YES completion:nil];
    } error:^(NSString *error) {
        [PHRAppDelegate hideLoading];
        [NSUtils showMessage:[NSString stringWithFormat:@"%@", error.description] withTitle:kLocalizedString(kTitleAlertError)];
    }];
}

- (void)requestUpdateFood {
    [[PHRClient instance] requestUpdateBabyFood:self.foodItem andCompleted:^(id params) {
        self.AddCallBack();
        BabyFoodModel *model  = [self.foodItem getBabyFoodModel];
        [[NSNotificationCenter defaultCenter] postNotificationName:PHRNotificationEditData object:model];
        [PHRAppDelegate hideLoading];
         [self dismissViewControllerAnimated:YES completion:nil];
    } error:^(NSString *error) {
        [PHRAppDelegate hideLoading];
        [NSUtils showMessage:[NSString stringWithFormat:@"%@", error.description] withTitle:kLocalizedString(kTitleAlertError)];
    }];
}


- (void) scrollViewScroll:(PHRSlider*)slider value:(double) valueScroll {
    value = valueScroll;
}

- (void)scrollToDefaultValue {
    [self.slider scrollToPosition:self.defaultValue];
}

- (void)dateTimeChanged:(NSDate *)date {
    dateTime = date;
}

- (IBAction)onTapBtnSave:(id)sender {
    if (!self.textFieldFood.text || [self.textFieldFood.text isEmpty]) {
        [NSUtils showMessage:kLocalizedString(kFoodMissFood) withTitle:APP_NAME];
        return;
    }
    if (self.textFieldFood.text.length > 50) {
        [NSUtils showMessage:kLocalizedString(kTextInputLong) withTitle:APP_NAME];
        return;
    }
    // assign if not exist
    if (!self.foodItem) {
        self.foodItem = [[ChildrenFoodModel alloc] init];
    }
    self.foodItem.food = self.textFieldFood.text;
    self.foodItem.imageUrl    = PHR_STR_NULL;
    self.foodItem.kcal = [NSString stringWithFormat:@"%.0f",value];
    self.foodItem.mealType = self.labelMealType.text;
    self.foodItem.date  = [UIUtils stringUTCDate:dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT];
    self.foodItem.note  = @"";
    
    [PHRAppDelegate showLoading];
    if (!self.modelID || [self.modelID isEqual: [NSNull null]]) {
        [self requestAddNewFood];
    } else {
        self.foodItem.childrenFoodID = self.modelID;
        [self requestUpdateFood];
    }
}

- (IBAction)touchChooseMealType:(id)sender {
    [self.textFieldFood resignFirstResponder];
    
    UIActionSheet *popup = [[UIActionSheet alloc] initWithTitle:kLocalizedString(kTitleActionSheet) delegate:self cancelButtonTitle:kLocalizedString(kCancel) destructiveButtonTitle:nil otherButtonTitles:
                            kLocalizedString(kRiceGruel),
                            kLocalizedString(kBabyFood),
                            kLocalizedString(kFruit),
                            kLocalizedString(kOther),
                            nil];
    [popup showInView:[UIApplication sharedApplication].keyWindow];
}

- (void)actionSheet:(UIActionSheet *)actionSheet clickedButtonAtIndex:(NSInteger)buttonIndex {
    if ([[actionSheet buttonTitleAtIndex:buttonIndex] isEqualToString:kLocalizedString(kCancel)]) {
        return;
    }
    self.labelMealType.text = [actionSheet buttonTitleAtIndex:buttonIndex];
}

@end
