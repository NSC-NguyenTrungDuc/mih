//
//  PatientClinicDelegate.h
//  PHR
//
//  Created by Tran Hoang Ha on 10/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "PatientClinicViewController.h"

@interface PatientClinicDelegate : NSObject
- (instancetype)initWithViewController:(PatientClinicViewController *)viewController andTableView:(UITableView *)tableView andListViewModel:(NSArray *)listViewModel;
- (CGFloat)heightForItem;
- (void)didSelectItemAtIndexPath:(NSIndexPath *)indexPath;
@end
