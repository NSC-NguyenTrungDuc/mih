package nta.med.service.ihis.handler.nuro;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.out.Out1003;
import nta.med.core.glossary.OrderStatus;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out1003Repository;
import nta.med.data.model.ihis.nuro.NuroORDERTRANSUpdateOCS1003SelectToInsert;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto.NuroORDERTRANSUpdateOCS1003Info;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.NuroORDERTRANSUpdateOCS1003Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class NuroORDERTRANSUpdateOCS1003Handler extends ScreenHandler<NuroServiceProto.NuroORDERTRANSUpdateOCS1003Request, SystemServiceProto.UpdateResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(NuroORDERTRANSUpdateOCS1003Handler.class);                                    
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository; 
	@Resource                                                                                                       
	private Out1003Repository out1003Repository; 
	@Resource
	private CommonRepository commonRepository;

	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroORDERTRANSUpdateOCS1003Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String bunho = request.getBunho();
		Double pkout1003 = null;
		Double pkout1001 = CommonUtils.parseDouble(request.getPkout1001());
		
		List<NuroORDERTRANSUpdateOCS1003SelectToInsert> listSelectToInsert = out1003Repository.getNuroORDERTRANSUpdateOCS1003SelectToInsert(hospCode, bunho, pkout1001,false, false);
		if(!CollectionUtils.isEmpty(listSelectToInsert)){
			for(NuroORDERTRANSUpdateOCS1003SelectToInsert info : listSelectToInsert){
				pkout1003 = CommonUtils.parseDouble(commonRepository.getNextVal("OUT1003_SEQ"));
				Out1003 out1003 = new Out1003();
				out1003.setHospCode(hospCode);
				out1003.setActingDate(info.getActingDate());
				out1003.setBunho(info.getBunho());
				out1003.setGubun(info.getGubun());
				out1003.setGwa(info.getGwa());
				out1003.setDoctor(info.getDoctor());
				out1003.setChojae(info.getChojae());
				out1003.setSeq(info.getSeq());
				out1003.setPkout1003(pkout1003);
				out1003.setFkout1001(pkout1001);
				out1003Repository.save(out1003);
			}
		}
		
		List<NuroORDERTRANSUpdateOCS1003Info> listUpdateOcs1003 = request.getOcsUpdItemList(); 
		if(!CollectionUtils.isEmpty(listUpdateOcs1003)){
			for(NuroORDERTRANSUpdateOCS1003Info item : listUpdateOcs1003){
				Date sunabDate = DateUtil.toDate(item.getSunabDate(), DateUtil.PATTERN_YYMMDD);
				Double pkocs1003 = CommonUtils.parseDouble(item.getPkocs1003());
				ocs1003Repository.updateOrderTransfer(sunabDate, pkout1003, pkocs1003, hospCode, OrderStatus.DO_NOT_TRANFER.getValue());
			}
		}
		
		response.setResult(true);
		return response.build();
	}
	
}