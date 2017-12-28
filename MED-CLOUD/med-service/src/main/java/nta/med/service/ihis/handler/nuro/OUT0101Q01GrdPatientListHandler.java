package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuro.OUT0101Q01GrdPatientListInfo;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OUT0101Q01GrdPatientListHandler extends ScreenHandler<NuroServiceProto.OUT0101Q01GrdPatientListRequest, NuroServiceProto.OUT0101Q01GrdPatientListResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OUT0101Q01GrdPatientListHandler.class);                                        
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;    
	@Resource
	private Adm0000Repository adm0000Repository;
	                                                                                                                
	@Override
	public boolean isValid(NuroServiceProto.OUT0101Q01GrdPatientListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getBirth()) && DateUtil.toDate(request.getBirth(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OUT0101Q01GrdPatientListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT0101Q01GrdPatientListRequest request) throws Exception {
		NuroServiceProto.OUT0101Q01GrdPatientListResponse.Builder response = NuroServiceProto.OUT0101Q01GrdPatientListResponse.newBuilder();

		String offset =  "0" ;
		if(!StringUtils.isEmpty(request.getOffset())){
			offset = request.getOffset();
		}
		Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		String suname2 = request.getSuname2();
		if(getLanguage(vertx, sessionId).equals(Language.JAPANESE.toString().toUpperCase())){
			suname2 = CommonUtils.convertToHalfWidthKana(suname2);
		}
		List<OUT0101Q01GrdPatientListInfo> listPatient = out0101Repository.getOUT0101Q01GrdPatientListInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				suname2, request.getSex(), DateUtil.toDate(request.getBirth(), DateUtil.PATTERN_YYMMDD), request.getTel(), startNum, CommonUtils.parseInteger(offset));
			if(!CollectionUtils.isEmpty(listPatient)){
				for(OUT0101Q01GrdPatientListInfo item : listPatient){
					NuroModelProto.OUT0101Q01GrdPatientListInfo.Builder info = NuroModelProto.OUT0101Q01GrdPatientListInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addItem(info);
				}
			}
		return response.build();
	}                                                                                                                 
}