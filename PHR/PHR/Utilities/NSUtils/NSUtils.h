//
//  NSUtils.h
//  PHR
//
//  Created by DEV-CongHT on 10/10/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MasterDataManager.h"
#import <CTAssetsPickerController/CTAssetsPickerController.h>

@interface NSUtils : NSObject{
    
}

+ (void)showErrorMessage:(NSURLSessionDataTask*)task andError:(NSError*)error;
+(BOOL)handleDataResponse:(NSDictionary*)response ;

// Check if input string contains an email adress
+(BOOL)containEmailAddress:(NSString*)input;

+(NSString*)getSubString:(NSString*)input length:(NSInteger)length;

+(void)addGestureToView:(UIView*)view withSelector:(SEL)selector;

+ (NSString*)getHexStringFromColor:(UIColor*)color;
+ (NSString *)removeWhiteSpaceFromString:(NSString *)inputString;
+ (UIImage *)imageWithView:(UIView *)view;
+ (UIImage *)imageWithColor:(UIColor *)color;

+ (void)setCommonButtonStyle:(UIButton*)button;
+ (void)setCommonButtonStyle:(UIButton*)button withColor:(UIColor*)color;

// Alert functions
+ (void)showMessage:(NSString *)message withTitle:(NSString *)title;
+ (void)showMessage:(NSString *)message withTitle:(NSString *)title andDelegate:(id)delegate;
+ (void)showMessage:(NSString *)message withTitle:(NSString *)title delegate:(id)delegate andTag:(NSInteger)tag;
+ (void)showMessage:(NSString *)message withTitle:(NSString *)title cancelButtonTitle:(NSString *)cancelTitle otherButtonTitles:(NSString *)otherTitle delegate:(id)delegate andTag:(NSInteger)tag;
+ (UIAlertView *)showAlertWithTitle:(NSString *)title message:(NSString *)message;

// Date functions
+ (NSDate *)dateFromString:(NSString *)dateString withFormat:(NSString *)dateFormat;
+ (NSString *)stringFromDate:(NSDate *)date withFormat:(NSString *)dateFormat;
+ (NSString *)stringFromDateRelative:(NSDate*)date;
+ (NSInteger)differeceDayFrom:(NSDate*)fromDate toDate:(NSDate*)toDate;
+ (NSDate *)getNextDateFromDate:(NSDate *)date;
+ (NSDate *)getPreviousDateFromDate:(NSDate *)date;
+ (NSString *)timeSeparateWith:(NSString *)examinationTime;

// NSUserDefaults functions
+ (void)setValue:(id)value forKey:(NSString*)key;
+ (void)setIntValue:(NSInteger)value forKey:(NSString *)key;
+ (void)setValue:(id)value forKeyPath:(NSString *)keyPath;
+ (void)setObject:(id)obj forKey:(NSString *)key;

// You can only store property list types (array, data, string, number, date, dictionary) or urls in NSUserDefaults. You'll need to convert your model object to store
//+ (void)setCustomizeObject:(id)obj forKey:(NSString *)key;
//+ (id)getCustomizeObjectWithKey:(NSString*)key;
+ (BOOL)boolForKey:(NSString*)key defaultValue:(BOOL)defaultValue;
+ (id)valueForKey:(NSString*)key;
+ (NSInteger)intValueForKey:(NSString *)key;
+ (id)valueForKeyPath:(NSString *)keyPath;
+ (id)objectForKey:(NSString *)key;
+ (void)removeObjectForKey:(NSString*)key;

// View Utils
+ (void)moveUp:(UIView*)view offset:(float)offset;
+ (void)moveDow:(UIView*)view offset:(float)offset;
+ (void)moveRight:(UIView*)view offset:(float)offset;
+ (void)moveLeft:(UIView*)view offset:(float)offset;

+ (void)moveUp:(UIView*)view offset:(float)offset animation:(BOOL)animation;
+ (void)moveDow:(UIView*)view offset:(float)offset animation:(BOOL)animation;
+ (void)moveRight:(UIView*)view offset:(float)offset animation:(BOOL)animation;
+ (void)moveLeft:(UIView*)view offset:(float)offset animation:(BOOL)animation;

+ (void)changeFrameFor:(UIView*)view newFrame:(CGRect)newFrame animation:(BOOL)animation;

+ (void)moveView:(UIView*)view below:(UIView*)topView  offSet:(float)offset;
+ (void)setGoneView:(UIView*)view;
+ (void)makeAutoLabelHeight:(UILabel*)label withContent:(NSString*)content;
+ (NSString *)formatToNumberFromString:(NSString *)numberString;


// Check JP Language
+ (BOOL)checkJPLanguage;
//generateJSONDataFromArrayOfObjects
+ (NSData*)generateJSONDataFromArrayOfObjects:(NSMutableArray*)array;
+ (NSData*)generateJSONDataFromDictionaryOfObjects:(NSDictionary*)dict;
+ (BOOL)checkObjectNull:(id)object;
+ (BOOL)checkDateIsToday:(NSDate*)date;
+ (MasterDataType)typeForMasterDataType:(NSString*) type;
+ (float)getStandardValue:(BOOL) isBaby masterDataType:(NSString*)type;
+ (CGPoint)getStandardBloodPressureValue:(BOOL) isBaby masterDataType:(NSString*)type;
+ (CGPoint)getMeanAndSdValue:(BOOL) isBaby masterDataType:(NSString*)type;
+ (NSArray*)getMeanDataForBodyFat:(BOOL) isBaby;
+ (NSArray*)getMeanDataForTemperature;
+ (NSArray*)getMeanDataForBloodPressure;
+ (NSArray*)getMeanDataForBMIAndWeight:(BOOL) isBaby  masterDataType:(NSString*)type;

+ (BOOL)hasAlertViewOnWindow;
+ (void)createPhotoLibrary:(id<CTAssetsPickerControllerDelegate>)delegate andViewController:(UIViewController*)controller;

@end
