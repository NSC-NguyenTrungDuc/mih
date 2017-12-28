//
//  NSUtils.m
//  PHR
//
//  Created by DEV-CongHT on 10/10/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "NSUtils.h"

@implementation NSUtils

+ (void)showErrorMessage:(NSURLSessionDataTask*)task andError:(NSError*)error {
    //    NSDictionary *userInfo = [error userInfo];
    //    NSError *underlyingError = [userInfo objectForKey:NSUnderlyingErrorKey];
    //    NSString *underlyingErrorDescription = [underlyingError localizedDescription];
    //    NSInteger statusCode = ((NSHTTPURLResponse*)task.response).statusCode;
    //    if(statusCode ==  500 ||  statusCode ==  405 || statusCode ==  404 ) {
    //        [self showMessage: [[NSHTTPURLResponse localizedStringForStatusCode:((NSHTTPURLResponse*)task.response).statusCode] capitalizedString] withTitle:LOCAL_ERROR];
    //    } else {
    //        [self showMessage:underlyingErrorDescription withTitle:LOCAL_ERROR];
    //    }
}

// Check response status and show error message if not success
+ (BOOL)handleDataResponse:(NSDictionary*)response {
    if(response && [[Validator getSafeString:[response  objectForKey:@"status"]]  isEqualToString:@"0"]) {
        if(response[@"message"]) {
            //            [self showMessage:[[response  objectForKey:@"message"] objectForKey:@"jp"] withTitle:APP_NAME];
            return NO;
        }
    }
    return YES;
}


// Check if input string contains an email adress
+ (BOOL)containEmailAddress:(NSString*)input {
    
    NSString *emailRegEx =
    @"(?:[a-z0-9!#$%\\&'*+/=?\\^_`{|}~-]+(?:\\.[a-z0-9!#$%\\&'*+/=?\\^_`{|}"
    @"~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\"
    @"x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-"
    @"z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5"
    @"]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-"
    @"9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21"
    @"-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])";
    NSPredicate *regExPredicate =
    [NSPredicate predicateWithFormat:@"SELF MATCHES %@", emailRegEx];
    BOOL myStringMatchesRegEx = [regExPredicate evaluateWithObject:input];
    
    return  myStringMatchesRegEx;
    
}

+ (NSString*)getSubString:(NSString*)input length:(NSInteger)length {
    
    if(input.length < length)
        return input;
    else {
        return  [NSString stringWithFormat:@"%@...", [input substringToIndex:length]];
    }
}

+ (void)addGestureToView:(UIView*)view withSelector:(SEL)selector {
    
    UITapGestureRecognizer * tapPress = [[UITapGestureRecognizer alloc] initWithTarget:self action:selector];
    tapPress.numberOfTapsRequired = 1;
    [view addGestureRecognizer:tapPress];
    view.userInteractionEnabled = YES;
}

+ (NSString*)getHexStringFromColor:(UIColor*)color {
    
    const CGFloat *components = CGColorGetComponents(color.CGColor);
    CGFloat r = components[0];
    CGFloat g = components[1];
    CGFloat b = components[2];
    NSString *hexString=[NSString stringWithFormat:@"#%02X%02X%02X", (int)(r * 255), (int)(g * 255), (int)(b * 255)];
    return hexString;
}

+ (NSString *)removeWhiteSpaceFromString:(NSString *)inputString{
    NSString *outputString = [inputString stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceCharacterSet]];
    return outputString;
}

+ (UIImage *)imageWithView:(UIView *)view{
    UIGraphicsBeginImageContextWithOptions(view.bounds.size, view.opaque, 0.0);
    [view.layer renderInContext:UIGraphicsGetCurrentContext()];
    
    UIImage * img = UIGraphicsGetImageFromCurrentImageContext();
    
    UIGraphicsEndImageContext();
    
    return img;
}

+ (UIImage *) imageWithColor:(UIColor *)color {
    CGRect rect = CGRectMake(0, 0, 1, 1);
    UIGraphicsBeginImageContext(rect.size);
    CGContextRef context = UIGraphicsGetCurrentContext();
    CGContextSetFillColorWithColor(context, [color CGColor]);
    //  [[UIColor colorWithRed:222./255 green:227./255 blue: 229./255 alpha:1] CGColor]) ;
    CGContextFillRect(context, rect);
    UIImage *img = UIGraphicsGetImageFromCurrentImageContext();
    UIGraphicsEndImageContext();
    return img;
}

+ (void)setCommonButtonStyle:(UIButton*)button {
    //    [self setCommonButtonStyle:button withColor:COLOR_SUM_CYAN];
}

+ (void)setCommonButtonStyle:(UIButton*)button withColor:(UIColor*)color {
    
    [button setBackgroundImage:[self imageWithColor:color] forState:UIControlStateNormal];
    button.layer.borderColor = [UIColor clearColor].CGColor;
    button.layer.borderWidth = 1.5;
    button.layer.cornerRadius = 5;
    button.clipsToBounds = YES;
}

#pragma mark - Alert functions

+ (void)showMessage:(NSString *)message withTitle:(NSString *)title {
    UIAlertView *alert = [[UIAlertView alloc] initWithTitle:title message:message delegate:nil cancelButtonTitle:kLocalizedString(kOK) otherButtonTitles: nil];
    [alert show];
}

+ (void)showMessage:(NSString *)message withTitle:(NSString *)title andDelegate:(id)delegate{
    UIAlertView *alert = [[UIAlertView alloc] initWithTitle:title message:message delegate:delegate cancelButtonTitle:kLocalizedString(kNo) otherButtonTitles:kLocalizedString(kYes), nil];
    [alert show];
}

+ (void)showMessage:(NSString *)message withTitle:(NSString *)title delegate:(id)delegate andTag:(NSInteger)tag{
    UIAlertView *alert = [[UIAlertView alloc] initWithTitle:title message:message delegate:delegate cancelButtonTitle:kLocalizedString(kNo) otherButtonTitles:kLocalizedString(kYes), nil];
    alert.tag = tag;
    [alert show];
}

+ (void)showMessage:(NSString *)message withTitle:(NSString *)title cancelButtonTitle:(NSString *)cancelTitle
  otherButtonTitles:(NSString *)otherTitle delegate:(id)delegate andTag:(NSInteger)tag{
    
    UIAlertView *alert = [[UIAlertView alloc] initWithTitle:title message:message delegate:delegate cancelButtonTitle:cancelTitle otherButtonTitles:otherTitle, nil];
    alert.tag = tag;
    alert.delegate = delegate;
    [alert show];
}

+ (UIAlertView *)showAlertWithTitle:(NSString *)title message:(NSString *)message {
    UIAlertView *alert = [[UIAlertView alloc]initWithTitle:title message:message delegate:nil cancelButtonTitle:kLocalizedString(kOK) otherButtonTitles:nil, nil];
    dispatch_async(dispatch_get_main_queue(), ^{
        [alert show];
    });
    return alert;
}

#pragma mark - Date functions

+ (NSDate *)dateFromString:(NSString *)dateString withFormat:(NSString *)dateFormat {
    NSDateFormatter *formatter = [[NSDateFormatter alloc] init];
    [formatter setDateFormat:dateFormat];
    NSLocale *timeLocale = [[NSLocale alloc] initWithLocaleIdentifier:PHR_DATETIME_LOCATE];
    [formatter setLocale:timeLocale];
    NSDate *ret = [formatter dateFromString:dateString];
    return ret;
}

+ (NSString *)stringFromDate:(NSDate *)date withFormat:(NSString *)dateFormat {
    NSDateFormatter *formatter = [[NSDateFormatter alloc] init];
    [formatter setDateFormat:dateFormat];
    
    NSLocale *timeLocale = [NSLocale currentLocale];
    [formatter setLocale:timeLocale];
    NSCalendar *calendar = [[NSCalendar alloc] initWithCalendarIdentifier:NSCalendarIdentifierGregorian];
    formatter.calendar = calendar;
    
    NSString *ret = [formatter stringFromDate:date];
    
    if (ret) {
        return ret;
    }
    return @"";
}

+ (NSString *)stringFromDateRelative:(NSDate*)date {
    NSDateFormatter *dateFormatter = [[NSDateFormatter alloc] init];
    
    [dateFormatter setDateStyle: NSDateFormatterMediumStyle];
    [dateFormatter setTimeStyle: NSDateFormatterShortStyle];
    [dateFormatter setDoesRelativeDateFormatting:YES];
    
    NSString *result = [dateFormatter stringFromDate:date];
    
    return result;
}

+ (NSInteger)differeceDayFrom:(NSDate*)fromDate toDate:(NSDate*)toDate {
    
    //DNSLog(@"Diff : %@ ==== %@ ",fromDate,toDate);
    NSCalendar *calendar = [NSCalendar currentCalendar];
    
    [calendar rangeOfUnit:NSCalendarUnitDay startDate:&fromDate
                 interval:NULL forDate:fromDate];
    [calendar rangeOfUnit:NSCalendarUnitDay startDate:&toDate
                 interval:NULL forDate:toDate];
    
    NSDateComponents *difference = [calendar components:NSCalendarUnitDay
                                               fromDate:fromDate toDate:toDate options:0];
    
    NSInteger diff =  [difference day];
    
    
    //DNSLog(@"Diff : %ld",diff);
    return diff;
}

+ (NSCalendar *)calendar{
    static NSCalendar *calendar;
    static dispatch_once_t once;
    
    dispatch_once(&once, ^{
#ifdef __IPHONE_8_0
        calendar = [[NSCalendar alloc] initWithCalendarIdentifier:NSCalendarIdentifierGregorian];
#else
        calendar = [[NSCalendar alloc] initWithCalendarIdentifier:NSGregorianCalendar];
#endif
        calendar.timeZone = [NSTimeZone localTimeZone];
    });
    
    return calendar;
}

+ (NSString *)timeSeparateWith:(NSString *)examinationTime {
    return [NSString stringWithFormat:@"%@:%@",
            [examinationTime substringToIndex:2],
            [examinationTime substringFromIndex:2]];
}

#pragma mark - NSUserDefaults functions

+ (void)setValue:(id)value forKey:(NSString*)key{
    [[NSUserDefaults standardUserDefaults] setValue:value forKey:key];
    [[NSUserDefaults standardUserDefaults] synchronize];
}

+ (void)setIntValue:(NSInteger)value forKey:(NSString *)key{
    [[NSUserDefaults standardUserDefaults] setInteger:value forKey:key];
    [[NSUserDefaults standardUserDefaults] synchronize];
}

+ (void)setValue:(id)value forKeyPath:(NSString *)keyPath{
    [[NSUserDefaults standardUserDefaults] setValue:value forKeyPath:keyPath];
    [[NSUserDefaults standardUserDefaults] synchronize];
}

+ (void)setObject:(id)obj forKey:(NSString *)key{
    [[NSUserDefaults standardUserDefaults] setObject:obj forKey:key];
    [[NSUserDefaults standardUserDefaults] synchronize];
}

+ (void)setCustomizeObject:(id)obj forKey:(NSString *)key{
    
    NSUserDefaults *def = [NSUserDefaults standardUserDefaults];
    [def setObject:[NSKeyedArchiver archivedDataWithRootObject:obj] forKey:key];
    [def synchronize];
}

+ (id)getCustomizeObjectWithKey:(NSString*)key{
    NSUserDefaults *def = [NSUserDefaults standardUserDefaults];
    NSData *data = [def objectForKey:key];
    return data ? [NSKeyedUnarchiver unarchiveObjectWithData:data] : nil;
}


+ (BOOL)boolForKey:(NSString*)key defaultValue:(BOOL)defaultValue {
    if ([[NSUserDefaults standardUserDefaults] dictionaryRepresentation][key] == nil){
        return defaultValue;
    }
    return [[NSUserDefaults standardUserDefaults] boolForKey:key];
}

+ (id)valueForKey:(NSString*)key{
    return [[NSUserDefaults standardUserDefaults] valueForKey:key];
}

+ (NSInteger)intValueForKey:(NSString *)key{
    return [[NSUserDefaults standardUserDefaults] integerForKey:key];
}

+ (id)valueForKeyPath:(NSString *)keyPath{
    return [[NSUserDefaults standardUserDefaults] valueForKeyPath:keyPath];
}

+ (id)objectForKey:(NSString *)key{
    return [[NSUserDefaults standardUserDefaults] objectForKey:key];
}

+ (void)removeObjectForKey:(NSString*)key{
    [[NSUserDefaults standardUserDefaults] removeObjectForKey:key];
    [[NSUserDefaults standardUserDefaults] synchronize];
}

#pragma mark  - UIView Moving Utils

+ (void)moveUp:(UIView*)view offset:(float)offset {
    
    [self moveUp:view offset:offset animation:NO];
}

+ (void)moveDow:(UIView*)view offset:(float)offset {
    
    [self moveDow:view offset:offset animation:NO];
}

+ (void)moveRight:(UIView*)view offset:(float)offset {
    [self moveRight:view offset:offset animation:NO];
}

+ (void)moveLeft:(UIView*)view offset:(float)offset {
    
    [self moveLeft:view offset:offset animation:NO];
}

+ (void)moveUp:(UIView*)view offset:(float)offset animation:(BOOL)animation {
    
    if(animation) {
        [UIView beginAnimations:nil context:NULL];
        [UIView setAnimationDuration:0.4];
    }
    
    view.frame=CGRectMake(view.frame.origin.x, view.frame.origin.y-offset, view.frame.size.width, view.frame.size.height);
    
    if(animation) {
        [UIView commitAnimations];
    }
}

+ (void)moveDow:(UIView*)view offset:(float)offset animation:(BOOL)animation {
    
    if(animation) {
        [UIView beginAnimations:nil context:NULL];
        [UIView setAnimationDuration:0.4];
    }
    
    view.frame=CGRectMake(view.frame.origin.x, view.frame.origin.y+offset, view.frame.size.width, view.frame.size.height);
    
    if(animation) {
        [UIView commitAnimations];
    }
    
}

+ (void)moveRight:(UIView*)view offset:(float)offset animation:(BOOL)animation {
    
    if(animation) {
        [UIView beginAnimations:nil context:NULL];
        [UIView setAnimationDuration:0.4];
    }
    view.frame=CGRectMake(view.frame.origin.x+offset, view.frame.origin.y, view.frame.size.width, view.frame.size.height);
    
    if(animation) {
        [UIView commitAnimations];
    }
    
}

+ (void)moveLeft:(UIView*)view offset:(float)offset animation:(BOOL)animation {
    
    if(animation) {
        [UIView beginAnimations:nil context:NULL];
        [UIView setAnimationDuration:0.4];
    }
    
    view.frame = CGRectMake(view.frame.origin.x-offset, view.frame.origin.y, view.frame.size.width, view.frame.size.height);
    
    if(animation) {
        [UIView commitAnimations];
    }
    
}

+ (void)changeFrameFor:(UIView*)view newFrame:(CGRect)newFrame animation:(BOOL)animation {
    
    if(animation) {
        [UIView beginAnimations:nil context:NULL];
        [UIView setAnimationDuration:0.4];
    }
    
    view.frame = newFrame;
    
    if(animation) {
        [UIView commitAnimations];
    }
    
}

+ (void)moveView:(UIView*)view below:(UIView*)topView  offSet:(float)offset {
    
    CGRect currentFrame = view.frame;
    currentFrame.origin.y = topView.frame.origin.y + topView.frame.size.height + offset;
    view.frame = currentFrame;
    
}

+ (void)setGoneView:(UIView*)view {
    
    [view setHidden:YES];
    view.frame = CGRectMake(view.frame.origin.x, view.frame.origin.y, view.frame.size.width, 0);
}

+ (void)makeAutoLabelHeight:(UILabel*)label withContent:(NSString*)content {
    label.text = content;
    label.numberOfLines = 0;
    
    NSAttributedString *attributedText =
    [[NSAttributedString alloc]
     initWithString:content
     attributes:@
     {
     NSFontAttributeName: label.font
     }];
    CGRect rect = [attributedText boundingRectWithSize:(CGSize){label.frame.size.width, CGFLOAT_MAX}
                                               options:NSStringDrawingUsesLineFragmentOrigin
                                               context:nil];
    CGSize size = rect.size;
    
    label.lineBreakMode = NSLineBreakByWordWrapping;
    
    label.frame=  CGRectMake(label.frame.origin.x, label.frame.origin.y, label.frame.size.width, size.height);
}


+ (NSString *)formatToNumberFromString:(NSString *)numberString{
    if ([Validator isNullOrNilObject:numberString]) {
        return nil;
    }
    NSNumber *firstNumber = [NSNumber numberWithInteger:[numberString integerValue]];
    NSNumberFormatter *formatter = [[NSNumberFormatter alloc] init];
    [formatter setNumberStyle:NSNumberFormatterDecimalStyle];
    NSString *convertNumber = [formatter stringForObjectValue:firstNumber];
    
    return convertNumber;
}

// Check device language is JP
+ (BOOL)checkJPLanguage{
    NSString * language = [[NSLocale preferredLanguages] objectAtIndex:0];
    return (language && [[language substringToIndex:2] isEqualToString:@"ja"]);
}
//@quytm add to fix bug: MED-7747[KCCK][PHR][PHR311-ListForm]Crash application when tap on Delete button -> generateData to redraw chart
//generateJSONDataFromArrayOfObjects
+ (NSData*)generateJSONDataFromArrayOfObjects:(NSMutableArray*)array
{
    NSData *jsonData = nil;
    NSError *error = nil;
    jsonData = [NSJSONSerialization dataWithJSONObject:array options:NSJSONWritingPrettyPrinted error:&error];
    return jsonData;
}
//generateJSONDataFromDictionaryOfObjects
+ (NSData*)generateJSONDataFromDictionaryOfObjects:(NSDictionary*)dict
{
    NSData *jsonData = nil;
    NSError *error = nil;
    jsonData = [NSJSONSerialization dataWithJSONObject:dict options:NSJSONWritingPrettyPrinted error:&error];
    return jsonData;
}

+ (BOOL)checkObjectNull:(id)object{
    return object == nil || object == [NSNull null];
}

+ (BOOL)checkDateIsToday:(NSDate*)date {
    NSCalendar *cal = [NSCalendar currentCalendar];
    NSDateComponents *components = [cal components:(NSCalendarUnitEra | NSCalendarUnitYear | NSCalendarUnitMonth | NSCalendarUnitDay) fromDate:[NSDate date]];
    NSDate *today = [cal dateFromComponents:components];
    components = [cal components:(NSCalendarUnitEra | NSCalendarUnitYear | NSCalendarUnitMonth | NSCalendarUnitDay) fromDate:date];
    NSDate *otherDate = [cal dateFromComponents:components];
    
    return [today isEqualToDate:otherDate];
}

+ (MasterDataType)typeForMasterDataType:(NSString*) type {
    if ([type isEqualToString:HKQuantityTypeIdentifierHeight]) {
        return MasterDataTypeHeightGirl;
    } else if ([type isEqualToString:HKQuantityTypeIdentifierBodyMass]) {
        return MasterDataTypeWeightGirl;
    } else if ([type isEqualToString:HKQuantityTypeIdentifierBodyFatPercentage]) {
        return MasterDataTypeBodyfat;
    } else if ([type isEqualToString:HKQuantityTypeIdentifierBodyMassIndex]) {
        return MasterDataTypeBmiGirl;
    } else if ([type isEqualToString:HKQuantityTypeIdentifierStepCount]) {
        return MasterDataTypeStepGirl;
    } else if ([type isEqualToString:HKQuantityTypeIdentifierDistanceWalkingRunning]) {
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierDietaryEnergyConsumed]) {
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierDietaryCarbohydrates]) {
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierDietaryFatTotal]) {

    } else if ([type isEqualToString:HKQuantityTypeIdentifierBodyTemperature]) {
        return MasterDataTypeTemperature;
    } else if ([type isEqualToString:HKQuantityTypeIdentifierHeartRate]) {
        return MasterDataTypeHeartrateGirl;
    } else if ([type isEqualToString:HKQuantityTypeIdentifierRespiratoryRate]) {
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic]) {
        return MasterDataTypeBloodGirl;
    } else if ([type isEqualToString:HKCategoryTypeIdentifierSleepAnalysis]) {
        //return MasterDataTypeSleep;
    }
    return MasterDataTypeNone;
}

+ (float)getStandardValue:(BOOL) isBaby masterDataType:(NSString*)type {
    float meanValue;
    if (isBaby) {
        meanValue = [MasterDataManager getMeanData:PHRAppStatus.currentBaby.isMen withType:[NSUtils  typeForMasterDataType:type] age:PHRAppStatus.currentBaby.age];
    } else {
        meanValue = [MasterDataManager getMeanData:PHRAppStatus.currentStandard.isMen withType:[NSUtils  typeForMasterDataType:type] age:PHRAppStatus.currentStandard.age];
    }
    return meanValue;
}

+ (CGPoint)getStandardBloodPressureValue:(BOOL) isBaby masterDataType:(NSString*)type {
    CGPoint meanValue;
    if (isBaby) {
        meanValue = [MasterDataManager getMeanDataBloodPressure:PHRAppStatus.currentBaby.isMen withType:[NSUtils  typeForMasterDataType:type] age:PHRAppStatus.currentBaby.age];
    } else {
        meanValue = [MasterDataManager getMeanDataBloodPressure:PHRAppStatus.currentStandard.isMen withType:[NSUtils  typeForMasterDataType:type] age:PHRAppStatus.currentStandard.age];
    }
    return meanValue;
}

+ (CGPoint)getMeanAndSdValue:(BOOL) isBaby masterDataType:(NSString*)type {
    CGPoint meanValue;
    if (isBaby) {
        meanValue = [MasterDataManager getMeanAndSdData:PHRAppStatus.currentBaby.isMen withType:[NSUtils  typeForMasterDataType:type] age:PHRAppStatus.currentBaby.age];
    } else {
        meanValue = [MasterDataManager getMeanAndSdData:PHRAppStatus.currentStandard.isMen withType:[NSUtils  typeForMasterDataType:type] age:PHRAppStatus.currentStandard.age];
    }
    return meanValue;
}

+ (NSArray*)getMeanDataForBodyFat:(BOOL) isBaby  {
    NSArray *array;
    if (isBaby) {
        array = [MasterDataManager getMeanDataForBodyFat:PHRAppStatus.currentBaby.isMen age:PHRAppStatus.currentBaby.age];
    } else {
        array = [MasterDataManager getMeanDataForBodyFat:PHRAppStatus.currentStandard.isMen age:PHRAppStatus.currentStandard.age];
    }
    return array;
}

+ (NSArray*)getMeanDataForBMIAndWeight:(BOOL) isBaby  masterDataType:(NSString*)type {
    NSArray *array;
    if (isBaby) {
        array = [MasterDataManager getMeanDataForBMIAndWeight:PHRAppStatus.currentBaby.isMen withType:[NSUtils  typeForMasterDataType:type] age:PHRAppStatus.currentBaby.age];
    } else {
        array = [MasterDataManager getMeanDataForBMIAndWeight:PHRAppStatus.currentStandard.isMen withType:[NSUtils  typeForMasterDataType:type] age:PHRAppStatus.currentStandard.age];
    }
    return array;
}

+ (NSArray*)getMeanDataForTemperature {
    NSArray *array;
    
    array = [MasterDataManager getMeanDataForTemperature:PHRAppStatus.currentStandard.age];

    return array;
}

+ (NSArray*)getMeanDataForBloodPressure {
    NSArray *array;
    
    array = [MasterDataManager getMeanDataForBloodPressure:PHRAppStatus.currentBaby.isMen age:PHRAppStatus.currentStandard.age];
    
    return array;
}

+ (BOOL)hasAlertViewOnWindow {
    for (id content in PHRAppDelegate.window.subviews) {
        if ([content isKindOfClass:[UIAlertView class]]) {
            return YES;
        }
    }
    return NO;
}

+ (NSDate *)getNextDateFromDate:(NSDate *)date {
    NSCalendar *calendar = [[NSCalendar alloc] initWithCalendarIdentifier:NSCalendarIdentifierGregorian];
    NSDateComponents *components = [[NSDateComponents alloc] init];
    components.day = 1;
    return [calendar dateByAddingComponents:components toDate:date options:0];
}

+ (NSDate *)getPreviousDateFromDate:(NSDate *)date {
    NSCalendar *calendar = [[NSCalendar alloc] initWithCalendarIdentifier:NSCalendarIdentifierGregorian];
    NSDateComponents *components = [[NSDateComponents alloc] init];
    components.day = -1;
    return [calendar dateByAddingComponents:components toDate:date options:0];
}

+ (void)createPhotoLibrary:(id<CTAssetsPickerControllerDelegate>)delegate andViewController:(UIViewController*)controller {
  
  UINavigationBar *navBar = [UINavigationBar appearanceWhenContainedIn:[CTAssetsPickerController class], nil];
  
  // set nav bar style to black to force light content status bar style
  navBar.barStyle = UIBarStyleBlack;
  // bar tint color
  navBar.barTintColor = [UIColor colorWithRed:0.0 green:122.0/255.0 blue:1.0 alpha:1.0];
  // tint color
  navBar.tintColor = [UIColor whiteColor];
  
  
  navBar.titleTextAttributes =
  @{NSForegroundColorAttributeName: [UIColor whiteColor],
    NSFontAttributeName : [FontUtils aileronRegularWithSize:14.0f]};
  
  // bar button item appearance
  UIBarButtonItem *barButtonItem = [UIBarButtonItem appearanceWhenContainedIn:[CTAssetsPickerController class], nil];
  [barButtonItem setTitleTextAttributes:@{NSFontAttributeName : [FontUtils aileronRegularWithSize:14.0f],
                                          NSForegroundColorAttributeName : [UIColor whiteColor]}
                               forState:UIControlStateNormal];
  
  [PHPhotoLibrary requestAuthorization:^(PHAuthorizationStatus status){
    dispatch_async(dispatch_get_main_queue(), ^{
      
      // init picker
      CTAssetsPickerController *picker = [[CTAssetsPickerController alloc] init];
      
      // set delegate
      picker.delegate = delegate;
      
      // create options for fetching photo only
      PHFetchOptions *fetchOptions = [PHFetchOptions new];
      fetchOptions.predicate = [NSPredicate predicateWithFormat:@"mediaType == %d", PHAssetMediaTypeImage];
      
      // assign options
      picker.assetsFetchOptions = fetchOptions;
      
      // set default album (Camera Roll)
      picker.defaultAssetCollection = PHAssetCollectionSubtypeSmartAlbumUserLibrary;
      picker.navigationController.navigationBar.translucent =  NO;
      picker.navigationController.navigationBar.backgroundColor = [UIColor whiteColor];
      // to present picker as a form sheet in iPad
      if (UI_USER_INTERFACE_IDIOM() == UIUserInterfaceIdiomPad)
        picker.modalPresentationStyle = UIModalPresentationFormSheet;
      
      // present picker
      [controller presentViewController:picker animated:YES completion:nil];
      
    });
  }];

}

@end
