//
//  RequestPatientClinicTest.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 11/4/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <XCTest/XCTest.h>
#import "ProgressCourseNoteViewController.h"


@interface RequestPatientClinicTest : XCTestCase

@property (strong, nonatomic) ProgressCourseNoteViewController *viewController;

@end

@interface ProgressCourseNoteViewController (Test)

- (void)handleResponseWithTask:(NSDictionary *)dictResponse;

@end

@implementation RequestPatientClinicTest

- (void)setUp {
  [super setUp];
  self.viewController = [[ProgressCourseNoteViewController alloc] initWithNibName:@"ProgressCourseNoteViewController" bundle:nil];
  
  // Put setup code here. This method is called before the invocation of each test method in the class.
}

- (void)tearDown {
  // Put teardown code here. This method is called after the invocation of each test method in the class.
  [super tearDown];
  self.viewController = nil;
}

- (void)testNilResponseShouldShowNothing {
  
  int expectedRowsInTable = 0;
  [self.viewController handleResponseWithTask:nil];
  XCTAssertEqual([self.viewController.tableViewClinic numberOfRowsInSection:0], expectedRowsInTable);
  
}

- (void)testWrongResponseShouldBeFalse {
  
  //Mock Data
//  NSString *response = [self getMockResponse:NO];
//  NSData * jsonData = [response dataUsingEncoding:NSUTF8StringEncoding];
//  NSError *jsonError;
//  id parsedData = [NSJSONSerialization JSONObjectWithData:jsonData options:NSJSONReadingAllowFragments error:&jsonError];
//  
//  //Execute function
//  [self.viewController handleResponseWithTask:parsedData];
//  
//  //Assert
//  PatientClinicTableViewCell *cell = (PatientClinicTableViewCell*) [self.viewController.tableViewClinic cellForRowAtIndexPath:[NSIndexPath indexPathForRow:0 inSection:0]];
//  //XCTAssertNil(cell.labelHospName);
  
}

- (void)testCorrectResponseShouldBeTrue {
  
  NSInteger expectedRowsInTable = 3;
  //Mock Data
  NSString *response = [self getMockResponse:YES];
  NSData * jsonData = [response dataUsingEncoding:NSUTF8StringEncoding];
  NSError *jsonError;
  id parsedData = [NSJSONSerialization JSONObjectWithData:jsonData options:NSJSONReadingAllowFragments error:&jsonError];
  
  //Execute function
  [self.viewController handleResponseWithTask:parsedData];
  
  //Assert
  XCTAssertEqual([self.viewController.tableViewClinic numberOfRowsInSection:0], expectedRowsInTable);
  
  
}

- (NSString*)getMockResponse:(BOOL)isCorrectResponse {
  NSBundle* plistPath = [NSBundle bundleForClass:[self class]];
  NSString *response;
  if (isCorrectResponse) {
   response = [[NSString alloc] initWithContentsOfFile:[plistPath pathForResource:@"ResponseCorrectPatientClinic" ofType:@"txt"] encoding:NSUTF8StringEncoding error:NULL];
  } else {
    response = [[NSString alloc] initWithContentsOfFile:[plistPath pathForResource:@"ResponseInCorrectPatientClinic" ofType:@"txt"] encoding:NSUTF8StringEncoding error:NULL];
  }
  
  return response;
}


@end
