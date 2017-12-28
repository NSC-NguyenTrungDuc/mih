//
//  FoodChildrenViewController.m
//  PHR
//
//  Created by SonNV1368 on 10/6/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "FoodChildrenViewController.h"
#import "NSString+Extension.h"

@interface FoodChildrenViewController () <UITextViewDelegate>

@end

@implementation FoodChildrenViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self setUpUI];
    [self setupNavigationBarTitle:kLocalizedString(kTitleFood) titleIcon:@"Icon_Baby_Food" rightItem:[self itemRightBabyKey:kSave]];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void) setUpUI {
    self.view.backgroundColor = [UIColor whiteColor];
    self.textViewNote.delegate = self;
    self.textViewNote.text = kLocalizedString(kNote);
    self.textViewNote.textColor = [UIColor lightGrayColor];
    
    [self.textFieldFood setFont:[FontUtils aileronRegularWithSize:14.0]];
    [self.textFieldKcalType setFont:[FontUtils aileronRegularWithSize:14.0]];
    
    [self.labelMealType setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:14.0];
    [self.labelMealTypeTitle setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:14.0];
    [self.textFieldKcalType setKeyboardType:UIKeyboardTypeDecimalPad];
    
    self.textFieldFood.delegate = self;
    self.textFieldKcalType.delegate = self;
    
    [self.textFieldKcalType setPlaceholder:kLocalizedString(kCalories)];
    
    [self.labelKcalUnit setStyleRegularToLabelWithSize:11.0];
    [self.textFieldFood setTextColor:PHR_COLOR_GRAY];
    [self.textFieldKcalType setTextColor:PHR_COLOR_GRAY];
    
    [self.labelMealType setText:kLocalizedString(kRiceGruel)];
    [self.labelMealTypeTitle setText:kLocalizedString(kTitleMealType)];
    [self.textFieldFood setPlaceholder:kLocalizedString(kTitleFood)];
    
    [self.labelMealType setTextColor:PHR_COLOR_GRAY];
    [self.labelKcalUnit setTextColor:PHR_COLOR_GRAY];
    
    //    [self.textFieldFood setValue:PHR_COLOR_GRAY
    //                      forKeyPath:@"_placeholderLabel.textColor"];
    //    [self.textFieldKcalType setValue:PHR_COLOR_GRAY
    //                          forKeyPath:@"_placeholderLabel.textColor"];
    if (self.idBabyFood > 0) {
        __weak __typeof(self) weakSelf = self;
        
        [[PHRClient instance] requestGetDetailBabyFoodsWithId:self.idBabyFood completed:^(id response) {
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
}

- (void)fillDataToView:(ChildrenFoodModel *)model {
    NSDate *dateTime = [UIUtils dateFromServerTimeString:model.date];
    [self.dateTimeFood updateTime:dateTime];
    self.textFieldFood.text = model.food;
    self.textFieldKcalType.text = model.kcal;
    self.labelMealType.text = model.mealType;
    self.textViewNote.text  = model.note;
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    [self setImageToBackgroundBaby:self.imageBackground];
    //[self resetViewbabyFood];
}

- (void)actionNavigationBarItemRight {
    if (!self.textFieldKcalType.text || [self.textFieldKcalType.text isEmpty]) {
        [NSUtils showMessage:kLocalizedString(kHealthMissKcal) withTitle:APP_NAME];
        return;
    }
    if (!self.textFieldFood.text || [self.textFieldFood.text isEmpty]) {
        [NSUtils showMessage:kLocalizedString(kFoodMissFood) withTitle:APP_NAME];
        return;
    }
    
    ChildrenFoodModel *babyFoodModel = [ChildrenFoodModel new];
    babyFoodModel.date        = [self.dateTimeFood stringDateParam];
    babyFoodModel.food        = self.textFieldFood.text;
    babyFoodModel.imageUrl    = PHR_STR_NULL;
    babyFoodModel.kcal        = self.textFieldKcalType.text;
    babyFoodModel.mealType    = self.labelMealType.text;
    babyFoodModel.note        = self.textViewNote.text;
    BabyFoodModel *model  = [babyFoodModel getBabyFoodModel];
    __weak __typeof(self) weakSelf = self;
    
    if(!self.idBabyFood || [self.idBabyFood isEmpty]) {
        [[PHRClient instance] requestAddNewBabyFoodWithObj:babyFoodModel andCompleted:^(id params) {
            NSLog(@"%@",params);
            NSString *newId = params[KEY_Content][KEY_Food_ID];
            babyFoodModel.childrenFoodID = newId;
            weakSelf.addFoodChildrenCallBack(babyFoodModel);
            model.food_id = newId;
            NSLog(@"IDDD %@",newId);
            [[NSNotificationCenter defaultCenter] postNotificationName:PHRNotificationAddNewData object:model];
            [weakSelf callBackPopView];
        } error:^(NSString *error) {
            [NSUtils showMessage:[NSString stringWithFormat:@"%@", error.description] withTitle:kLocalizedString(kTitleAlertError)];
        }];
    } else {
        babyFoodModel.childrenFoodID = self.idBabyFood;
        [[PHRClient instance] requestUpdateBabyFood:babyFoodModel andCompleted:^(id params) {
            weakSelf.addFoodChildrenCallBack(babyFoodModel);
            model.food_id = self.idBabyFood;
            [[NSNotificationCenter defaultCenter] postNotificationName:PHRNotificationEditData object:model];
            [weakSelf callBackPopView];
        } error:^(NSString *error) {
            [NSUtils showMessage:[NSString stringWithFormat:@"%@", error.description] withTitle:kLocalizedString(kTitleAlertError)];
        }];
    }
}

- (void)resetViewbabyFood {
    [self.dateTimeFood setDatetime:[NSDate date]];
    [self.textFieldFood setText:PHR_STR_NULL];
    [self.textFieldKcalType setText:PHR_STR_NULL];
    [self.textViewNote setText:kLocalizedString(kNote)];
}

- (void)callBackPopView {

    [self.navigationController popViewControllerAnimated:YES];
}

#pragma mark - UITextView Delegate

- (void)textViewDidBeginEditing:(UITextView *)textView {
    [self animateTextView:YES];
    if ([textView.text isEqualToString:kLocalizedString(kNote)]) {
        textView.text = PHR_STR_NULL;
        textView.textColor = PHR_COLOR_GRAY;
    }
    [textView becomeFirstResponder];
}

- (void)textViewDidEndEditing:(UITextView *)textView {
    [self animateTextView:NO];
    if ([textView.text isEqualToString:PHR_STR_NULL]) {
        textView.text = kLocalizedString(kNote);
        textView.textColor = [UIColor lightGrayColor];
    }
    [textView resignFirstResponder];
}

- (void)animateTextView:(BOOL) up {
    const int movementDistance = 150.0;
    const float movementDuration = 0.3f;
    int movement= movement = (up ? -movementDistance : movementDistance);
    
    [UIView beginAnimations: @"anim" context: nil];
    [UIView setAnimationBeginsFromCurrentState: YES];
    [UIView setAnimationDuration: movementDuration];
    self.view.frame = CGRectOffset(self.view.frame, 0, movement);
    [UIView commitAnimations];
}

#pragma mark -

- (IBAction)touchChooseMealType:(id)sender {
    [self.textFieldFood resignFirstResponder];
    [self.textFieldKcalType resignFirstResponder];
    
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
