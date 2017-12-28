//
//  AppDelegateTest.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 11/17/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <XCTest/XCTest.h>
#import <OCMock/OCMock.h>
#import "MainViewController.h"
#import "AcceptCallingViewController.h"

@interface AppDelegateTest : XCTestCase
@property(nonatomic, strong) AppDelegate *appDelegate;
@end

@interface AppDelegate (Test)

- (void)deleteExpiredLocalNotification;
- (void)openAnswerCallingScreen:(NSDictionary*)userInfo;

@end

@implementation AppDelegateTest

- (void)setUp {
  [super setUp];
  self.appDelegate = (AppDelegate *)[UIApplication sharedApplication].delegate;
  MainViewController *homeViewController = [[MainViewController alloc] initWithNibName:NSStringFromClass([MainViewController class]) bundle:nil];
  [self.appDelegate.navigationController pushViewController:homeViewController animated:YES];
  // Put setup code here. This method is called before the invocation of each test method in the class.
}

- (void)tearDown {
  // Put teardown code here. This method is called after the invocation of each test method in the class.
  [super tearDown];
  self.appDelegate = nil;
}

- (void)testDeleteExpiredLocalNotification_WithNoExpiredDate_ShouldEqual4 {
  
  NSInteger expectedNumberOfLocalNotication = 4;
  //Clear all data before test
  [[UIApplication sharedApplication] cancelAllLocalNotifications];
  //Create mock data
  [self createLocalNotification:[NSDate date] withAddingDateInterval:1];
  [self createLocalNotification:[NSDate date] withAddingDateInterval:2];
  [self createLocalNotification:[NSDate date] withAddingDateInterval:3];
  [self createLocalNotification:[NSDate date] withAddingDateInterval:4];
  //Execute function
  [self.appDelegate deleteExpiredLocalNotification];
  
  NSMutableArray *arrayAfterDelete  = [NSMutableArray arrayWithArray:[[UIApplication sharedApplication] scheduledLocalNotifications]];
  XCTAssertEqual(arrayAfterDelete.count, expectedNumberOfLocalNotication);
  
}

- (void)testDeleteExpiredLocalNotification_WithOneExpiredDate_ShouldEqual3 {
  
  NSInteger expectedNumberOfLocalNotication = 3;
  //Clear all data before test
  [[UIApplication sharedApplication] cancelAllLocalNotifications];
  //Create mock data - 1 expired
  [self createLocalNotification:[NSDate date] withAddingDateInterval:1];
  [self createLocalNotification:[NSDate date] withAddingDateInterval:2];
  [self createLocalNotification:[NSDate date] withAddingDateInterval:3];
  [self createLocalNotification:[NSDate date] withAddingDateInterval:-1];
  //Execute function
  [self.appDelegate deleteExpiredLocalNotification];
  
  NSMutableArray *arrayAfterDelete  = [NSMutableArray arrayWithArray:[[UIApplication sharedApplication] scheduledLocalNotifications]];
  XCTAssertEqual(arrayAfterDelete.count, expectedNumberOfLocalNotication);
}

- (void)testDeleteExpiredLocalNotification_WithAllExpiredDate_ShouldEqual0 {
  
  NSInteger expectedNumberOfLocalNotication = 0;
  //Clear all data before test
  [[UIApplication sharedApplication] cancelAllLocalNotifications];
  //Create mock data
  [self createLocalNotification:[NSDate date] withAddingDateInterval:-2];
  [self createLocalNotification:[NSDate date] withAddingDateInterval:-1];
  [self createLocalNotification:[NSDate date] withAddingDateInterval:-3];
  [self createLocalNotification:[NSDate date] withAddingDateInterval:-4];
  //Execute function
  [self.appDelegate deleteExpiredLocalNotification];
  
  NSMutableArray *arrayAfterDelete  = [NSMutableArray arrayWithArray:[[UIApplication sharedApplication] scheduledLocalNotifications]];
  XCTAssertEqual(arrayAfterDelete.count, expectedNumberOfLocalNotication);
}

- (void)testOpenAnswerCallingScreen_WithCorrectUserInfo_ShouldGotoAnswerCallingScreen {
  
  NSString *response = [self getMockResponseUserInfo:YES];
  NSData * jsonData = [response dataUsingEncoding:NSUTF8StringEncoding];
  NSError *jsonError;
  id parsedData = [NSJSONSerialization JSONObjectWithData:jsonData options:NSJSONReadingAllowFragments error:&jsonError];
  
  [self.appDelegate openAnswerCallingScreen:parsedData];
  
  XCTestExpectation *completionExpectation = [self expectationWithDescription:@"WaitingForWhatever"];
  double delayInSeconds = 3.0;
  dispatch_time_t popTime = dispatch_time(DISPATCH_TIME_NOW, (int64_t)(delayInSeconds * NSEC_PER_SEC));
  dispatch_after(dispatch_time(DISPATCH_TIME_NOW, popTime * NSEC_PER_SEC), dispatch_get_main_queue(), ^{
    XCTAssertTrue([self.appDelegate.navigationController.topViewController isKindOfClass:[AcceptCallingViewController class]],@"View Controller not pushed properly");
    [completionExpectation fulfill];
  });
  [self waitForExpectationsWithTimeout: delayInSeconds+2 handler:nil];
}

- (void)testOpenAnswerCallingScreen_WithIncorrectUserInfo_ShouldStayOnMainScreen {
  
  NSString *response = [self getMockResponseUserInfo:YES];
  NSData * jsonData = [response dataUsingEncoding:NSUTF8StringEncoding];
  NSError *jsonError;
  id parsedData = [NSJSONSerialization JSONObjectWithData:jsonData options:NSJSONReadingAllowFragments error:&jsonError];

  [self.appDelegate openAnswerCallingScreen:parsedData];
  
  XCTestExpectation *completionExpectation = [self expectationWithDescription:@"WaitingForWhatever"];
  double delayInSeconds = 3.0;
  dispatch_time_t popTime = dispatch_time(DISPATCH_TIME_NOW, (int64_t)(delayInSeconds * NSEC_PER_SEC));
  dispatch_after(dispatch_time(DISPATCH_TIME_NOW, popTime * NSEC_PER_SEC), dispatch_get_main_queue(), ^{
    XCTAssertTrue([self.appDelegate.navigationController.topViewController isKindOfClass:[AcceptCallingViewController class]],@"View Controller not pushed properly");
    [completionExpectation fulfill];
  });
  [self waitForExpectationsWithTimeout: delayInSeconds+2 handler:nil];
}

- (UILocalNotification*)createLocalNotification:(NSDate*)date withAddingDateInterval:(int)addingDate {
  UILocalNotification* localNotification = [[UILocalNotification alloc] init];
  NSTimeInterval time = floor([date timeIntervalSinceReferenceDate] / 60.0) * 60.0;
  NSDate *dateWithoutSecond = [NSDate dateWithTimeIntervalSinceReferenceDate:time];
  
  localNotification.fireDate = dateWithoutSecond;
  localNotification.alertBody = kLocalizedString(kTakeYourMedicine);
  localNotification.alertAction = @"Show me the item";
  localNotification.repeatInterval = NSCalendarUnitDay;
  localNotification.timeZone = [NSTimeZone systemTimeZone];
  localNotification.soundName = UILocalNotificationDefaultSoundName;// @"Sound name";
  
  NSString *keyNotification = [NSString stringWithFormat:@"%@AndPresKey%@",[UIUtils stringDate:localNotification.fireDate withFormat:PHR_CLIENT_TIME_FORMAT_FULL],[NSString stringWithFormat:@"1"]];
  NSDate *keyEndDate = [date dateByAddingTimeInterval:addingDate * 86400];
  NSMutableDictionary *userInfo = [NSMutableDictionary dictionaryWithObject:keyNotification forKey:@"ID"];
  [userInfo setObject:keyEndDate forKey:PHR_REMIND_END_DATE];
  localNotification.userInfo = userInfo;
  [[UIApplication sharedApplication] scheduleLocalNotification:localNotification];
  return localNotification;
}

- (NSString*)getMockResponseUserInfo:(BOOL)isCorrectResponse {
  NSBundle* plistPath = [NSBundle bundleForClass:[self class]];
  NSString *response;
  if (isCorrectResponse) {
    response = [[NSString alloc] initWithContentsOfFile:[plistPath pathForResource:@"UserInfoNotification" ofType:@"txt"] encoding:NSUTF8StringEncoding error:NULL];
  } else {
    response = [[NSString alloc] initWithContentsOfFile:[plistPath pathForResource:@"IncorrectUserInfoNotification" ofType:@"txt"] encoding:NSUTF8StringEncoding error:NULL];
  }
  
  return response;
}

@end
