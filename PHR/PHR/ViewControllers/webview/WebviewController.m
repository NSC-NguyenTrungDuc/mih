//
//  WebviewController.m
//  PHR
//
//  Created by NextopHN on 4/15/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "WebviewController.h"

@interface WebviewController () <UIWebViewDelegate>

@end

@implementation WebviewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self.webview setDelegate:self];
    [self.btnClose setTitle:kLocalizedString(kClose) forState:UIControlStateNormal];
    self.btnClose.layer.cornerRadius = 5;
}

- (void)viewWillAppear:(BOOL)animated{
    [super viewWillAppear:animated];
    if (self.mRequest) {
        [self.webview loadRequest:self.mRequest];
    }
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

- (void)webViewDidStartLoad:(UIWebView *)webView{
    NSLog(@"Start load");
    [self.loading startAnimating];
    self.loading.hidden = NO;
}

- (void)webViewDidFinishLoad:(UIWebView *)webView{
    NSLog(@"Done load");
    [self.loading stopAnimating];
    self.loading.hidden = YES;
}

- (void)webView:(UIWebView *)webView didFailLoadWithError:(nullable NSError *)error {
    NSLog(@"%d",(int)error.code);
}

- (IBAction)actionClose:(id)sender {
    [self.navigationController popViewControllerAnimated:YES];
}
@end
