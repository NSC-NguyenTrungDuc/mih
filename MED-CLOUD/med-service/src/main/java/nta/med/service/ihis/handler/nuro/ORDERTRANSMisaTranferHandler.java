package nta.med.service.ihis.handler.nuro;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.out.Out1003;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out1003Repository;
import nta.med.data.model.ihis.nuro.NuroORDERTRANSUpdateOCS1003SelectToInsert;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisServiceProto.UpdateResponse;
import nta.med.service.ihis.proto.NuroModelProto.ORDERTRANSMisaTranferInfo;
import nta.med.service.ihis.proto.NuroServiceProto.ORDERTRANSMisaTranferRequest;

@Service
@Scope("prototype")
@Transactional
public class ORDERTRANSMisaTranferHandler extends ScreenHandler<ORDERTRANSMisaTranferRequest, UpdateResponse> {
	@Resource
	private Out1003Repository out1003Repository;
	@Resource
	private CommonRepository commonRepository;
	@Resource
	private Ocs1003Repository ocs1003Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			ORDERTRANSMisaTranferRequest request) throws Exception {
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String bunho = request.getBunho();
		Double pkout1003 = null;
		Integer updateResult = 0;
		Double pkout1001 = CommonUtils.parseDouble(request.getPkout1001());
		
		List<NuroORDERTRANSUpdateOCS1003SelectToInsert> listSelectToInsert = out1003Repository.getNuroORDERTRANSUpdateOCS1003SelectToInsert(hospCode, bunho, pkout1001,true, true);
		if(!CollectionUtils.isEmpty(listSelectToInsert)){
			NuroORDERTRANSUpdateOCS1003SelectToInsert info = listSelectToInsert.get(0);
			pkout1003 =  out1003Repository.getNuroORDERTRANSUpdateOCS1003Pkocs1003IfExists(hospCode, pkout1001, info);
			if(pkout1003 == null){
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
				out1003.setFkout1001(pkout1001);
				out1003.setPkout1003(pkout1003);
				out1003Repository.save(out1003);
			}
		}
		
		List<ORDERTRANSMisaTranferInfo> listOrderTransMisaTranfer = request.getLstList();
		for(ORDERTRANSMisaTranferInfo misaTranfer : listOrderTransMisaTranfer){
			Date sunabDate = DateUtil.toDate(misaTranfer.getSunabDate(), DateUtil.PATTERN_YYMMDD);
			Double pkocs1003 = CommonUtils.parseDouble(misaTranfer.getPkocs1003());
			updateResult = ocs1003Repository.updateORDERTRANOcs1003Update(sunabDate, pkout1003, pkocs1003, hospCode);
			if(updateResult <= 0){
				response.setResult(false);
				throw new ExecutionException();
			}
		}
		
		response.setResult(true);
		return response.build();
	}
}
