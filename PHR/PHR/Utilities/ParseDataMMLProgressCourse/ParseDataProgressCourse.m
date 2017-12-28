//
//  ParseDataProgressCourse.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 12/1/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "ParseDataProgressCourse.h"
#import "OrderModel.h"

static NSString *XML_WRONG_LT = @"&lt;";
static NSString *XML_WRONG_GT = @"&gt;";
static NSString *XML_RIGHT_LT = @"<";
static NSString *XML_RIGHT_GT = @">";

@implementation ParseDataProgressCourse


+ (NSString*)replaceWrongXMLData:(NSString*)inputString {
  NSString* result = inputString;
  result = [result stringByReplacingOccurrencesOfString:XML_WRONG_LT withString:XML_RIGHT_LT];
  result = [result stringByReplacingOccurrencesOfString:XML_WRONG_GT withString:XML_RIGHT_GT];
  return result;
}

+ (NSArray*)getProgressCourseModule:(NSArray*)inputArray {
  NSMutableArray* resultProgressCourse = [NSMutableArray new];
  NSMutableArray* resultDiseases = [NSMutableArray new];
  for (NSDictionary *dict in inputArray) {
    NSString *contentModuleType = [dict valueForKeyPath:KEYPath_GetMmlContentModuleType];
    if (contentModuleType && [contentModuleType isEqualToString:KEY_progressCourseValue]){
      [resultProgressCourse addObject:dict];
      
    } else if (contentModuleType && [contentModuleType isEqualToString:KEY_DiseasesValue]){
      [resultDiseases addObject:dict];
    }
  }
  
  return [[NSArray alloc] initWithObjects:resultProgressCourse, resultDiseases, nil];
}

+ (NSMutableArray*)getProgressCourseModuleOrderList:(NSMutableArray*)inputArray {
  NSMutableArray* result = [NSMutableArray new];
  
  NSMutableArray* arrayDatetime = [NSMutableArray new];
  for (NSDictionary *dict in inputArray) {
    [arrayDatetime addObject:[dict valueForKeyPath:KEYPath_GetMmlConfirmDate]];
    NSMutableArray *arrayListOrder = [NSMutableArray new];
    NSArray *arrayProblemItem = [dict valueForKeyPath:KEYPath_GetMmlProblemItem];
    if (arrayProblemItem.count > 0) {
      id arrayOrders = [arrayProblemItem valueForKeyPath:KEYPath_GetMmlListOrders];
      if ([arrayOrders isKindOfClass:[NSDictionary class]]) {
        OrderModel *orderModel = [[OrderModel alloc] initWithDictionary:(NSDictionary*)arrayOrders error:nil];
        if (orderModel){
          [arrayListOrder addObject:orderModel];
        }
      } else {
        for (id dictOrderModel in arrayOrders) {
          if ([dictOrderModel isKindOfClass:[NSDictionary class]]) {
            OrderModel *orderModel = [[OrderModel alloc] initWithDictionary:(NSDictionary*)dictOrderModel error:nil];
            if (orderModel){
              [arrayListOrder addObject:orderModel];
            }
          } else if ([dictOrderModel isKindOfClass:[NSArray class]]){
            NSArray *arr = (NSArray*)dictOrderModel;
            for (NSObject *dictOrderModel in arr) {
              OrderModel *orderModel = [[OrderModel alloc] initWithDictionary:(NSDictionary*)dictOrderModel error:nil];
              if (orderModel){
                [arrayListOrder addObject:orderModel];
              }
            }
          }
        }
      }
      
    }
    [result addObject:arrayListOrder];
  }
  if (arrayDatetime.count == 0) {
    return result;
  }
  NSMutableArray* sortedResult = [NSMutableArray new];
  NSMutableArray *p = [NSMutableArray arrayWithCapacity:arrayDatetime.count];
  for (NSUInteger i = 0 ; i != arrayDatetime.count ; i++) {
    [p addObject:[NSNumber numberWithInteger:i]];
  }
  [p sortWithOptions:0 usingComparator:^NSComparisonResult(NSString *obj1, NSString *obj2) {
    NSDate *date1 = [UIUtils dateFromString:[arrayDatetime objectAtIndex:[obj1 intValue]] withFormat:PHR_BIRTHDAY_SERVER_FORMAT];
    NSDate *date2 = [UIUtils dateFromString:[arrayDatetime objectAtIndex:[obj2 intValue]] withFormat:PHR_BIRTHDAY_SERVER_FORMAT];
    return [date2 compare:date1];
  }];
  
  [p enumerateObjectsUsingBlock:^(id obj, NSUInteger idx, BOOL *stop) {
    NSUInteger pos = [obj intValue];
    [sortedResult addObject:[result objectAtIndex:pos]];
  }];
  return sortedResult;
}
@end
