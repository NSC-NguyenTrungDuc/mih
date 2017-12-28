//
//  PatientClinicDelegate.m
//  PHR
//
//  Created by Tran Hoang Ha on 10/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PatientClinicDelegate.h"
#import "PHRBookingListViewController.h"
#import "PatientClinicTableViewCell.h"
#import "BookingViewController.h"
#import "AcceptCallingViewController.h"

@interface PatientClinicDelegate()
@property (nonatomic, strong) NSArray *listViewModel;
@property (nonatomic, strong) PatientClinicViewController *viewController;
@property (nonatomic, strong) UITableView *tableView;
@end

@implementation PatientClinicDelegate
- (instancetype)initWithViewController:(PatientClinicViewController *)viewController andTableView:(UITableView *)tableView andListViewModel:(NSArray *)listViewModel {
  self = [super init];
  if (self) {
    self.viewController = viewController;
    self.listViewModel = listViewModel;
    self.tableView = tableView;
  }
  return self;
}

- (CGFloat)heightForItem {
  return [PatientClinicTableViewCell cellHeight];
}

- (void)didSelectItemAtIndexPath:(NSIndexPath *)indexPath {
  [self.tableView deselectRowAtIndexPath:indexPath animated:YES];
  BookingViewController *bookingListVC = [[BookingViewController alloc] initWithNibName:NSStringFromClass([BookingViewController class]) bundle:nil];
  PatientClinicViewModel *patientClinicAccount = _listViewModel[indexPath.row];
  bookingListVC.patientClinicAccount = patientClinicAccount;
  [self.viewController.navigationController pushViewController:bookingListVC animated:YES];
  //Replace here
//  AcceptCallingViewController *controller = [[AcceptCallingViewController alloc] initWithNibName:NSStringFromClass([AcceptCallingViewController class]) bundle:nil];
//  [self.viewController.navigationController pushViewController:controller animated:YES];
}

@end
