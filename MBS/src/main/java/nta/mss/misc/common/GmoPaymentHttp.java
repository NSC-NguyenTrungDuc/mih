package nta.mss.misc.common;

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;
import java.net.UnknownHostException;

public class GmoPaymentHttp {

	public GmoPaymentHttp() {}
	
	public Message cancelationAuthorization(String version, String shopId, String shopPass, String accessId, String accessPass, String JobCd) throws Exception {
		// Build Parameters:
		String urlParameters = "VerSion=" + URLEncoder.encode(version, "UTF-8") 
				+ "&ShopID=" + URLEncoder.encode(shopId, "UTF-8") 
				+ "&ShopPass=" + URLEncoder.encode(shopPass, "UTF-8") 
				+ "&AccessID=" + URLEncoder.encode(accessId, "UTF-8") 
				+ "&AccessPass=" + URLEncoder.encode(accessPass, "UTF-8") 
				+ "&JobCd=" + URLEncoder.encode(JobCd, "UTF-8");

		// Send Request:
		String result = excutePost(MssConfiguration.getInstance().getGmoPayUrlCancelation(), urlParameters);
		System.out.println(result);
		
		Message message = new Message();
		message.status = "status";
		message.content = "messageContent";
		
		if (!result.contains("ErrCode")) {
			message.status = "success";
			message.content = result;
		} else {
			message.status = "fail";
			message.content = result;
		}
		
		return message;
	}

	public String excutePost(String targetURL, String urlParameters) throws UnknownHostException {
		URL url;
		HttpURLConnection connection = null;
		try {
			// Create connection
			url = new URL(targetURL);
			connection = (HttpURLConnection) url.openConnection();
			connection.setRequestMethod("POST");
			connection.setRequestProperty("Content-Type",
					"application/x-www-form-urlencoded");

			connection.setRequestProperty("Content-Length",
					"" + Integer.toString(urlParameters.getBytes().length));
			connection.setRequestProperty("Content-Language", "en-US");

			connection.setUseCaches(false);
			connection.setDoInput(true);
			connection.setDoOutput(true);

			// Send request
			DataOutputStream wr = new DataOutputStream(
					connection.getOutputStream());
			wr.writeBytes(urlParameters);
			wr.flush();
			wr.close();

			// Get Response
			InputStream is = connection.getInputStream();
			BufferedReader rd = new BufferedReader(new InputStreamReader(is));
			String line;
			StringBuffer response = new StringBuffer();
			while ((line = rd.readLine()) != null) {
				response.append(line);
				response.append('\n');
			}
			rd.close();
			return response.toString();
		} catch (UnknownHostException e) {
			throw e;
		} catch (Exception e) {
			return "";
		} finally {
			if (connection != null) {
				connection.disconnect();
			}
		}
	}

	public static class Message {
		public String status = null, content = null;

		public Message() {
		}

		public Message(String status, String content) {
			super();
			this.status = status;
			this.content = content;
		}

		public String toString() {
			if (status != null) {
				return status + ": " + content;
			}
			return null;
		}
	}
}
