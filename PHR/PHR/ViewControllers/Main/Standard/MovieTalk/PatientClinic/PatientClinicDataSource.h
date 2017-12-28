//
//  PatientClinicDataSource.h
//  PHR
//
//  Created by Tran Hoang Ha on 10/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface PatientClinicDataSource : NSObject
- (instancetype)initWithTableView:(UITableView *)tableView andListViewModel:(NSArray *)listViewModel;
- (NSUInteger)numberOfItemInSections:(NSInteger)section;
- (UITableViewCell *)cellForItemAtIndexPath:(NSIndexPath *)indexPath;
@end
