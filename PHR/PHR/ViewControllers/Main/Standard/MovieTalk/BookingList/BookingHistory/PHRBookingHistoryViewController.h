//
//  PHRBookingHistoryViewController.h
//  PHR
//
//  Created by Dao Xuan Tu on 11/8/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Base2ViewController.h"
#import "BookingHistoryTableViewCell.h"
#import "PHRBookingHistoryModel.h"
#import "PatientClinicViewModel.h"
#import <AVFoundation/AVFoundation.h>
#import "STKAudioPlayer.h"
#import "STKAutoRecoveringHTTPDataSource.h"
#import "SampleQueueId.h"


@interface PHRBookingHistoryViewController : Base2ViewController <STKAudioPlayerDelegate>
@property (nonatomic, strong) PatientClinicViewModel *patientClinicAccount;
@property (weak, nonatomic) IBOutlet UILabel *lblMessage;
@property (weak, nonatomic) IBOutlet UITableView *tableView;
- (void)clearAudioPlayer;
@end
