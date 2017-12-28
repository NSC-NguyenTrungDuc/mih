package nta.med.service.emr.handler;

import nta.med.core.domain.emr.EmrBookmark;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.emr.EmrBookmarkRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.math.BigDecimal;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class OCS2015U04AddBookmarkHandler extends ScreenHandler<EmrServiceProto.OCS2015U04AddBookmarkRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U04AddBookmarkHandler.class);                                    
	@Resource                                                                                                       
	private EmrBookmarkRepository emrBookmarkRepository;

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U04AddBookmarkRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = insertOCS2015U04AddBookmark(request);
		response.setResult(result);
		return response.build();
	}
	
	private boolean insertOCS2015U04AddBookmark (EmrServiceProto.OCS2015U04AddBookmarkRequest request) {
		try {
			EmrBookmark emrBookmark = new EmrBookmark();
			emrBookmark.setEmrRecordId(CommonUtils.parseInteger(request.getEmrRecordId()));
			emrBookmark.setBookmarkText(request.getBookmarkText());
			emrBookmark.setNaewonDate(DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD_BLANK));
			emrBookmark.setPkout1001(CommonUtils.parseDouble(request.getPkout1001()));
			emrBookmark.setSysId(request.getUpdId());
			emrBookmark.setUpdId(request.getUpdId());
			emrBookmark.setActiveFlg(new BigDecimal(1));
//			emrBookmark.setCreated(new Timestamp(System.currentTimeMillis()));
//			emrBookmark.setUpdated(new Timestamp(System.currentTimeMillis()));
			emrBookmarkRepository.save(emrBookmark);
			return true;
		}  catch (Exception e){
			LOGGER.error(e.getMessage(), e);
			return false;
		}	
	}
}