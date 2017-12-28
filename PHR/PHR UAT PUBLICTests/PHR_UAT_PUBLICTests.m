//
//  PHR_UAT_PUBLICTests.m
//  PHR UAT PUBLICTests
//
//  Created by Nguyen Thanh Tung on 11/2/16.
//  Copyright © 2016 Sofia. All rights reserved.
//
#import <UIKit/UIKit.h>
#import <XCTest/XCTest.h>
#import "ProgressCourseNoteViewController.h"


@interface PHR_UAT_PUBLICTests : XCTestCase
@property (strong, nonatomic) ProgressCourseNoteViewController *viewController;
@end

@interface ProgressCourseNoteViewController (Test)

- (void)handleResponseWithTask:(NSDictionary *)dictResponse;

@end

@implementation PHR_UAT_PUBLICTests {
  
}
- (void)setUp {
    [super setUp];
    // Put setup code here. This method is called before the invocation of each test method in the class.
}

- (void)tearDown {
    // Put teardown code here. This method is called after the invocation of each test method in the class.
    [super tearDown];
}

- (void)testExample {
  XCTAssert(true,"hehe");
    // This is an example of a functional test case.
    // Use XCTAssert and related functions to verify your tests produce the correct results.
}

- (void)testPerformanceExample {
    // This is an example of a performance test case.
    [self measureBlock:^{
        // Put the code you want to measure the time of here.
    }];
}

@end
