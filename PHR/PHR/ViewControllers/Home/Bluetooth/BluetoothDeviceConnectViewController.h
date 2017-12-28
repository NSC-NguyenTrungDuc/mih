//
//  BluetoothDeviceConnectViewController.h
//  PHR
//
//  Created by BillyMobile on 6/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "BluetoothDevice.h"
#import "BluetoothManager.h"


@interface BluetoothDeviceConnectViewController : Base2ViewController<UITableViewDataSource, UITableViewDelegate, UITextFieldDelegate>{
    
}
@property (weak, nonatomic) IBOutlet UITableView *tableViewContent;

@end
