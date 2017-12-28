//
//  WebviewController.h
//  PHR
//
//  Created by NextopHN on 4/15/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"

@interface WebviewController : Base2ViewController

@property (weak, nonatomic) IBOutlet UIButton *btnClose;
@property (strong, nonatomic) NSMutableURLRequest * mRequest;
@property (weak, nonatomic) IBOutlet UIWebView *webview;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *loading;

- (IBAction)actionClose:(id)sender;
@end
