//
//  MovieHistoryTest.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 11/17/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <XCTest/XCTest.h>
#import <OHHTTPStubs/OHHTTPStubs.h>
#import <OHHTTPStubs/OHPathHelpers.h>
#import "PHRBookingHistoryViewController.h"
#import "BookingHistoryTableViewCell.h"


@interface MovieHistoryTest : XCTestCase

@property (strong, nonatomic) PHRBookingHistoryViewController *viewController;

@end

@interface PHRBookingHistoryViewController (Test)

- (void)handleResponseApiMT07:(NSDictionary *)response;

@end


@implementation MovieHistoryTest

- (void)setUp {
  [super setUp];
  self.viewController = [[PHRBookingHistoryViewController alloc] initWithNibName:@"PHRBookingHistoryViewController" bundle:nil];
  [self.viewController viewDidLoad];
  NSString *mockResponseData = [self getMockResponse:YES];
  NSData * jsonData = [mockResponseData dataUsingEncoding:NSUTF8StringEncoding];
  NSError *jsonError;
  id parsedData = [NSJSONSerialization JSONObjectWithData:jsonData options:NSJSONReadingAllowFragments error:&jsonError];
  [self.viewController handleResponseApiMT07:parsedData];
  
}

- (void)tearDown {
 
  [super tearDown];
  self.viewController = nil;
}

- (void)testViewController_ThatViewLoads {
  XCTAssertNotNil(self.viewController.view, @"View not initiated properly");
}

- (void)testParentViewHasTableViewSubview {
  NSArray *subviews = self.viewController.view.subviews;
  XCTAssertTrue([subviews containsObject:self.viewController.tableView], @"View does not have a table subview");
}

- (void)testThatViewConformsToUITableViewDataSource {
  XCTAssertTrue([self.viewController conformsToProtocol:@protocol(UITableViewDataSource) ], @"View does not conform to UITableView datasource protocol");
}

- (void)testThatTableViewHasDataSource {
  XCTAssertNotNil(self.viewController.tableView.dataSource, @"Table datasource cannot be nil");
}

- (void)testThatViewConformsToUITableViewDelegate {
  XCTAssertTrue([self.viewController conformsToProtocol:@protocol(UITableViewDelegate) ], @"View does not conform to UITableView delegate protocol");
}

- (void)testTableViewIsConnectedToDelegate {
  XCTAssertNotNil(self.viewController.tableView.delegate, @"Table delegate cannot be nil");
}

- (void)testTableViewCellCreateCellsWithReuseIdentifier {
  NSIndexPath *indexPath = [NSIndexPath indexPathForRow:0 inSection:0];
  UITableViewCell *cell = [self.viewController.tableView cellForRowAtIndexPath:indexPath];
  NSString *expectedReuseIdentifier = @"TableViewCellIdentifier";
  XCTAssertTrue([cell.reuseIdentifier isEqualToString:expectedReuseIdentifier], @"Table does not create reusable cells");
}

- (void)testCellTableViewCell_WithCorrectResponse_ShouldDisplayOnTableCorrectly {
  
  NSString *expectedDate = @"28/09/2016 21:20";
  BookingHistoryTableViewCell *cell = [self.viewController.tableView cellForRowAtIndexPath:[NSIndexPath indexPathForItem:0 inSection:0]];
  XCTAssertTrue([cell.lblDay.text isEqualToString:expectedDate]);
}

- (void)testHandleResponseApiMT07_WithCorrectResponse_ShouldDisplayOnTableCorrectly {
  
  NSInteger expectedRowsInTable = 10;
  NSInteger realData = [self.viewController.tableView numberOfRowsInSection:0];
  XCTAssertEqual(realData, expectedRowsInTable);
}

- (NSString*)getMockResponse:(BOOL)isCorrectResponse {
  NSBundle* plistPath = [NSBundle bundleForClass:[self class]];
  NSString *response;
  if (isCorrectResponse) {
    response = [[NSString alloc] initWithContentsOfFile:[plistPath pathForResource:@"RecordListResponse" ofType:@"txt"] encoding:NSUTF8StringEncoding error:NULL];
  }
  
  return response;
}



@end
