package nta.med.core.infrastructure;

import nta.med.core.glossary.MonitorKey;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import java.util.concurrent.atomic.AtomicLong;

public class MonitorLog {

	static Log LOG = LogFactory.getLog(MonitorLog.class);

	public static AtomicLong TOTAL_MESSAGE = new AtomicLong(0);
	public static AtomicLong TOTAL_MESSAGE_COMPRESSED = new AtomicLong(0);;
	public static AtomicLong TOTAL_BYTES_BEFORE_COMPRESS = new AtomicLong(0);;
	public static AtomicLong TOTAL_BYTES_REDUCE_AFTER_COMPRESSED = new AtomicLong(0);;
	public static void writeMonitorLog(MonitorKey key, String content){
		LOG.info("[MONITOR_LOG]" + key.getValue() + ": " + content);

	}
}
