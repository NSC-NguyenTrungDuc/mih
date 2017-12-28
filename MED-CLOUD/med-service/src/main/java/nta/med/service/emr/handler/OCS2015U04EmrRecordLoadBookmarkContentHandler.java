package nta.med.service.emr.handler;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.emr.EmrBookmarkRepository;
import nta.med.data.model.ihis.emr.OCS2015U04EmrRecordLoadBookmarkContentInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS2015U04EmrRecordLoadBookmarkContentHandler extends ScreenHandler<EmrServiceProto.OCS2015U04EmrRecordLoadBookmarkContentRequest, EmrServiceProto.OCS2015U04EmrRecordLoadBookmarkContentResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U04EmrRecordLoadBookmarkContentHandler.class);                                    
	@Resource                                                                                                       
	private EmrBookmarkRepository emrBookmarkRepository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U04EmrRecordLoadBookmarkContentResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U04EmrRecordLoadBookmarkContentRequest request) throws Exception {
		EmrServiceProto.OCS2015U04EmrRecordLoadBookmarkContentResponse.Builder response = EmrServiceProto.OCS2015U04EmrRecordLoadBookmarkContentResponse.newBuilder();
		List<OCS2015U04EmrRecordLoadBookmarkContentInfo> list = emrBookmarkRepository.getOCS2015U04EmrRecordLoadBookmarkContentInfo(request.getEmrRecordId(), getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if (!CollectionUtils.isEmpty(list)){
			for (OCS2015U04EmrRecordLoadBookmarkContentInfo item:list){
				EmrModelProto.OCS2015U04EmrRecordLoadBookmarkContentInfo.Builder info = EmrModelProto.OCS2015U04EmrRecordLoadBookmarkContentInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getEmrBookmarkId() != null) {
					info.setEmrBookmarkId(item.getEmrBookmarkId().toString());
				}
				if (!StringUtils.isEmpty(item.getBookmarkText())) {
					info.setBookmarkText(item.getBookmarkText());
				}
				if (item.getNaewonDate() != null) {
					info.setNaewonDate(DateUtil.toString(item.getNaewonDate(), DateUtil.PATTERN_YYMMDD));
				}
				if (!StringUtils.isEmpty(item.getSysId())) {
					info.setSysId(item.getSysId());
				}
				if (!StringUtils.isEmpty(item.getUserNm())) {
					info.setUserNm(item.getUserNm());
				}
				if (!StringUtils.isEmpty(item.getGwa())) {
					info.setGwa(item.getGwa());
				}
				if (!StringUtils.isEmpty(item.getGwaName())) {
					info.setGwaName(item.getGwaName());
				}
				response.addEmrBookmarkContentList(info);
			}
		}
		return response.build();
	}
}