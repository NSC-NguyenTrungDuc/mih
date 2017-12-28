//
//  HealthViewController.m
//  PHR
//
//  Created by DEV-MinhNN on 10/1/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "HealthViewController.h"
#import "HealthItem.h"
#import "NSString+Extension.h"

@interface HealthViewController () {
    NSMutableArray *arrayTextField;
}
@property (nonatomic, strong) HealthItem *health;

@end

@implementation HealthViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view from its nib.
    arrayTextField = [[NSMutableArray alloc] initWithObjects:self.txtHeight,self.txtWeight,self.txtWaistline,self.txtChestSize,self.txtLowBlood,self.txtHighBlood, nil];
    [self initializeHealthView];
    [self setupNavigationBarTitle:kLocalizedString(kTitleHealth) titleIcon:@"Health" rightItem:kLocalizedString(kSave)];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    [self setImageToBackgroundStandard:self.backgroundImage];
}

#pragma mark - Implement override methods
- (void)actionNavigationBarItemRight{
    
    __weak __typeof__(self) weakSelf = self;
    // check
    if (!self.txtPercentage.text || [self.txtPercentage.text isEmpty]) {
        [NSUtils showMessage:kLocalizedString(kHealthMissPercent) withTitle:APP_NAME];
        return;
    }
    if (!self.datetimeView.datetime) {
        [NSUtils showMessage:kLocalizedString(kHealthMissDatetime) withTitle:APP_NAME];
        return;
    }
    if (!self.txtHeight.text || [self.txtHeight.text isEmpty]) {
        [NSUtils showMessage:kLocalizedString(kHealthMissHeight) withTitle:APP_NAME];
        return;
    }
    if (!self.txtWeight.text || [self.txtWeight.text isEmpty]) {
        [NSUtils showMessage:kLocalizedString(kHealthMissWeight) withTitle:APP_NAME];
        return;
    }
    if (!self.txtWaistline.text || [self.txtWaistline.text isEmpty]) {
        [NSUtils showMessage:kLocalizedString(kHealthMissWaistline) withTitle:APP_NAME];
        return;
    }
    if (!self.txtChestSize.text || [self.txtChestSize.text isEmpty]) {
        [NSUtils showMessage:kLocalizedString(kHealthMissChestSize) withTitle:APP_NAME];
        return;
    }
    if (!self.txtLowBlood.text || [self.txtLowBlood.text isEmpty]) {
        [NSUtils showMessage:kLocalizedString(kHealthMissLowBlood) withTitle:APP_NAME];
        return;
    }
    if (!self.txtHighBlood.text || [self.txtHighBlood.text isEmpty]) {
        [NSUtils showMessage:kLocalizedString(kHealthMissHighBlood) withTitle:APP_NAME];
        return;
    }
    if (self.txtHeight.text && ![self.txtHeight.text isEmpty]
        && self.txtWeight.text && ![self.txtWeight.text isEmpty]) {
        NSScanner *scannerHeight = [NSScanner scannerWithString:self.txtHeight.text];
        NSScanner *scannerWeight = [NSScanner scannerWithString:self.txtWeight.text];
        BOOL isNumericHeight = [scannerHeight scanFloat:NULL] && [scannerHeight isAtEnd];
        BOOL isNumericWeight = [scannerWeight scanFloat:NULL] && [scannerWeight isAtEnd];
        if (!isNumericHeight || !isNumericWeight) {
            [NSUtils showMessage:kLocalizedString(kHealthNumberInvalidHeightAndWeight) withTitle:APP_NAME];
            return;
        }
    }
    
    // assign
    if (!self.health) {
        self.health = [[HealthItem alloc] init];
    }
    self.health.dateRecord     = [self.datetimeView stringDateParam];
    self.health.height         = self.txtHeight.text;
    self.health.weight         = self.txtWeight.text;
    self.health.waistLine      = self.txtWaistline.text;
    self.health.chestSize      = self.txtChestSize.text;
    self.health.lowBloodPress  = self.txtLowBlood.text;
    self.health.highBloodPress = self.txtHighBlood.text;
    self.health.percentageFat  = self.txtPercentage.text;
    self.health.note           = self.noteTextView.text;
    self.health.bmi            = [self calulateBMI];
    
    if (!self.standardHealthId || [self.standardHealthId isEmpty]) {
        [PHRAppDelegate showLoading];
        // Request add item
        [[PHRClient instance] requestAddNewHealth:self.health completed:^(id response){
            [PHRAppDelegate hideLoading];
            if (response) {
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                if (newDict) {
                    self.health = [HealthItem initHealthWithObj:newDict];
                    self.addHealthCallBack(self.health);
                }
            }
            [self.navigationController popViewControllerAnimated:YES];
        }error:^(NSString *error){
            [PHRAppDelegate hideLoading];
            [NSUtils showMessage:error withTitle:APP_NAME];
        }];
    } else {
        [PHRAppDelegate hideLoading];
        self.health.healthId = self.standardHealthId;
        [[PHRClient instance] requestUpdateStandardHealth:self.health andCompleted:^(id params) {
            [PHRAppDelegate hideLoading];
            self.addHealthCallBack(self.health);
            [weakSelf actionBackToPopView];
        } error:^(NSString *error) {
            [PHRAppDelegate hideLoading];
            
        }];
    }
}

- (NSString*)calulateBMI
{
    NSString *BMI;
    if (self.txtHeight.text && ![self.txtHeight.text isEmpty]
        && self.txtWeight.text && ![self.txtWeight.text isEmpty]) {
        float height = [self.txtHeight.text floatValue];
        float weight = [self.txtWeight.text floatValue];
        height = height / 100; // convert to m
        float xbmi = weight / (height*height);
        BMI = [NSString stringWithFormat:@"%0.2f",xbmi];
        NSLog(@"BMI: %@",BMI);
    }
    return BMI;
}

- (void)actionBackToPopView {
    [self.navigationController popViewControllerAnimated:YES];
}

#pragma mark - Initialize Health View

- (void)initializeHealthView {
    // Datetime
    [self.datetimeView setActionSelectDate:^(){
        
    }];
    
    // Percentage
    self.txtPercentage.placeholder = kLocalizedString(kPHPercentOfFat);
    self.txtPercentage.textColor = PHR_COLOR_GRAY;
    self.txtPercentage.delegate = self;
    
    /* --------------------------------- Note Style --------------------------------- */
    [self.noteTextView setDelegate:self];
    self.noteTextView.text = kLocalizedString(kNote);
    self.noteTextView.textColor = [UIColor lightGrayColor];
    
    [self.txtHeight setPlaceholder:kLocalizedString(kPHHeight)];
    [self.txtWeight setPlaceholder:kLocalizedString(kPHWeight)];
    [self.txtWaistline setPlaceholder:kLocalizedString(kPHWaistline)];
    [self.txtChestSize setPlaceholder:kLocalizedString(kPHChestSize)];
    [self.txtLowBlood setPlaceholder:kLocalizedString(kPHLowBlood)];
    [self.txtHighBlood setPlaceholder:kLocalizedString(kPHHighBlood)];
    
    if (self.standardHealthId && self.standardHealthId != [NSNull class]) {
//        __weak __typeof(self) weakSelf = self;
//        [[PHRClient instance] requestDetailStandardHealthWithId:self.standardHealthId andCompletion:^(StandardHealthModel *responseObject) {
//            [weakSelf fillDataToView:responseObject];
//        } error:^(NSString *error) {
//            [NSUtils showMessage:[NSString stringWithFormat:@"%@", error.description] withTitle:kLocalizedString(kTitleAlertError)];
//        }];
    }
}

- (void)fillDataToView:(StandardHealthModel *)model {
    [self.datetimeView updateTime:[UIUtils dateFromServerTimeString:model.datetime_record]];
    self.standardHealthId = model.id;
    [self.txtHeight setText:model.height];
    [self.txtWeight setText:model.weight];
    [self.txtChestSize setText:model.chest_size];
    [self.txtWaistline setText:model.waist_line];
    [self.txtHighBlood setText:model.high_blood_press];
    [self.txtLowBlood setText:model.low_blood_press];
    [self.txtPercentage setText:model.perc_fat];
    
    if (model.note.length == 0) {
        //[self touchButtonParentNote:nil];
        [self.noteTextView setText:[NSString stringWithFormat:@"%@", model.note]];
    }
}


#pragma mark - UITextView Delegate

- (void)textViewDidBeginEditing:(UITextView *)textView {
    if ([textView.text isEqualToString:kLocalizedString(kNote)]) {
        textView.text = @"";
        textView.textColor = PHR_COLOR_GRAY;
    }
    [textView becomeFirstResponder];
}

- (void)textViewDidEndEditing:(UITextView *)textView {
    if ([textView.text isEqualToString:@""]) {
        textView.text = kLocalizedString(kNote);
        textView.textColor = [UIColor lightGrayColor];
    }
    [textView resignFirstResponder];
}

#pragma mark - UITextField Delegate

- (BOOL)textFieldShouldReturn:(UITextField *)textField {
    [textField resignFirstResponder];
    return YES;
}

- (void)touchesBegan:(NSSet<UITouch *> *)touches withEvent:(UIEvent *)event {
    [self.noteTextView resignFirstResponder];
    [self.txtPercentage resignFirstResponder];
    for (UITextField *objText in arrayTextField) {
        [objText resignFirstResponder];
    }
}

@end
