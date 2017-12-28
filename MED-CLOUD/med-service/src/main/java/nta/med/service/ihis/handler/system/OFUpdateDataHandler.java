package nta.med.service.ihis.handler.system;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ocs.Ocs0300;
import nta.med.core.domain.ocs.Ocs0301;
import nta.med.core.domain.ocs.Ocs0303;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs0300Repository;
import nta.med.data.dao.medi.ocs.Ocs0301Repository;
import nta.med.data.dao.medi.ocs.Ocs0303Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.OFUpdateOCS0303UpdateDataInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OFUpdateDataRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OFUpdateDataResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class OFUpdateDataHandler extends ScreenHandler <SystemServiceProto.OFUpdateDataRequest, SystemServiceProto.OFUpdateDataResponse> {                     
	@Resource                                                                                                       
	private Ocs0300Repository ocs0300Repository;                                                                    
	@Resource
    private Ocs0301Repository ocs0301Repository;
	@Resource
	private CommonRepository commonRepository;
	@Resource
	private Ocs0303Repository ocs0303Repository;
	
	@Override                                                                                                       
	public OFUpdateDataResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OFUpdateDataRequest request)
			throws Exception  {                                                                   
  	   	SystemServiceProto.OFUpdateDataResponse.Builder response = SystemServiceProto.OFUpdateDataResponse.newBuilder(); 
      	String hospCode = getHospitalCode(vertx, sessionId);
		Double aPkSeq = null;
		Boolean updateResult1 = false;
		Boolean updateResult2 = false;
		Boolean updateResult3 = false;
		//1 UpdateOCS0300
		if(request.getExistData().equalsIgnoreCase("Y")){
			aPkSeq = CommonUtils.parseDouble(request.getPkSeq());
			updateResult1 = true;
			updateResult2 = true;
			updateResult3 = true;
		}else{
			Double pkSeq = ocs0300Repository.getMaxPkSeq(hospCode, request.getMembGubun(), request.getMemb());
			if(pkSeq == null || pkSeq.equals(new Double(0))){
				pkSeq = new Double(1);
			}
			Double seq= ocs0300Repository.getSeq(hospCode, request.getMembGubun(), request.getMemb());
			if(seq == null || seq.equals(new Double(0))){
				seq = new Double(1);
			}
			insertOcs0300(request, pkSeq, seq, hospCode);
			updateResult1 = true;
			aPkSeq = pkSeq;
		}
		//2 UpdateOcs0301
		String aYaksokCode = null;
		if(updateResult1){
			Double seq2= ocs0301Repository.getMaxPkSeqOcs0301(hospCode, request.getMemb() , aPkSeq);
			if(seq2 == null || seq2.equals(new Double(0))){
				seq2=  new Double(1);
			}
			aYaksokCode = request.getInputTab() + "/" + request.getMemb() + "/" + String.format("%.0f",aPkSeq) + "/" + String.format("%.0f",seq2);
			insertOcs0301(request, aYaksokCode, seq2, aPkSeq, hospCode);
			updateResult2 = true;
		}
		
		// 3UpdateOcs0303
		if(updateResult2){
			Double pkOcs0303 = null;
			for(OFUpdateOCS0303UpdateDataInfo info : request.getUpdateDataItemList()){
				if(request.getSelectYn().equalsIgnoreCase("N")){
					continue;
				}
				if(StringUtils.isEmpty(info.getPkocs0303())){
					pkOcs0303 = CommonUtils.parseDouble(commonRepository.getNextVal("OCS0303_SEQ"));
					if(pkOcs0303 == null || pkOcs0303.equals(new Double(0))){
						throw new ExecutionException(response.build());
					}
				}else{
					pkOcs0303= CommonUtils.parseDouble(info.getPkocs0303());
				}
				Double newSeq= ocs0303Repository.getMaxSeqByYakSokCodeAndFkocs0300Seq(hospCode, info.getMemb(), aYaksokCode, aPkSeq);
				if(newSeq == null || newSeq.equals(new Double(0))){
					newSeq = new Double(1);
				}
				insertOcs0303(request, info, pkOcs0303, newSeq, aPkSeq, hospCode, aYaksokCode);
				updateResult3 = true;
			}
		}
		response.setUpdateResult1(updateResult1);
		response.setUpdateResult2(updateResult2);
		response.setUpdateResult3(updateResult3);	
		return response.build();
	}

	private void insertOcs0300(SystemServiceProto.OFUpdateDataRequest request, Double pkSeq, Double seq, String hospCode) {
	    	Ocs0300 ocs0300 = new Ocs0300();
	    	ocs0300.setSysDate(new Date());
	    	ocs0300.setSysId(request.getUserId());
	    	ocs0300.setUpdDate(new Date());
	    	ocs0300.setUpdId(request.getUserId());
	    	ocs0300.setHospCode(hospCode);
	    	ocs0300.setMemb(request.getMemb());
	    	ocs0300.setPkSeq(pkSeq);
	    	ocs0300.setYaksokGubun(request.getYaksokGubun());
	    	ocs0300.setYaksokGubunName(request.getYaksokGubunName());
	    	ocs0300.setSeq(seq);
	    	ocs0300.setMembGubun(request.getMembGubun());
	    	ocs0300.setInputTab(StringUtils.isEmpty(request.getInputTab()) ? null : request.getInputTab());
	    	ocs0300Repository.save(ocs0300);
	    }
	
	 private void insertOcs0301(SystemServiceProto.OFUpdateDataRequest request, String aYaksokCode, Double seq, Double aPkSeq, String hospCode) {
	    	Ocs0301 ocs0301 = new Ocs0301();
	    	ocs0301.setSysDate(new Date());
	    	ocs0301.setSysId(request.getUserId());
	    	ocs0301.setUpdDate(new Date());
	    	ocs0301.setUpdId(request.getUserId());
	    	ocs0301.setMemb(request.getMemb());
	    	ocs0301.setYaksokCode(aYaksokCode);
	    	ocs0301.setYaksokName(request.getYaksokName());
	    	ocs0301.setSeq(seq);
	    	ocs0301.setFkocs0300Seq(aPkSeq);
	    	ocs0301.setHospCode(hospCode);
	    	ocs0301.setMembGubun(StringUtils.isEmpty(request.getMembGubun()) ? null : request.getMembGubun()); 
	    	ocs0301Repository.save(ocs0301);
	    }
	 
	 private void insertOcs0303(SystemServiceProto.OFUpdateDataRequest request, OFUpdateOCS0303UpdateDataInfo info, Double pkOcs0303, Double newSeq, Double aPkSeq, String hospCode, String aYaksokCode) {
	    	Ocs0303 ocs0303 = new Ocs0303();
	    	ocs0303.setSysDate(new Date());
	    	ocs0303.setSysId(info.getUserId());
	    	ocs0303.setUpdDate(new Date());
	    	//ocs0303.setMemb(info.getMemb());
	    	//ocs0303.setYaksokCode(info.getYaksokCode());
	    	ocs0303.setMemb(request.getMemb());
	    	ocs0303.setYaksokCode(aYaksokCode);
	    	ocs0303.setGroupSer(CommonUtils.parseDouble((info.getGroupSer())));
	    	ocs0303.setHangmogCode(info.getHangmogCode());
	    	ocs0303.setSeq(newSeq);
	    	ocs0303.setPkocs0303(pkOcs0303);
	    	ocs0303.setSpecimenCode(info.getSpecimenCode());
	    	ocs0303.setSuryang(CommonUtils.parseDouble(info.getSuryang()));
	    	ocs0303.setOrdDanui(StringUtils.isEmpty(info.getOrdDanui()) ? null : info.getOrdDanui());
	    	ocs0303.setDvTime(StringUtils.isEmpty(info.getDvTime()) ? null : info.getDvTime());
	    	ocs0303.setDv(CommonUtils.parseDouble(info.getDv()));
	    	ocs0303.setNalsu(CommonUtils.parseDouble(info.getNalsu()));
	    	ocs0303.setJusa(StringUtils.isEmpty(info.getJusa()) ? null : info.getJusa());
	    	ocs0303.setBogyongCode(StringUtils.isEmpty(info.getBogyongCode()) ? null : info.getBogyongCode());
	    	ocs0303.setEmergency(StringUtils.isEmpty(info.getEmergency()) ? null : info.getEmergency());
	    	ocs0303.setMuhyo(StringUtils.isEmpty(info.getMuhyo()) ? null : info.getMuhyo());
	    	ocs0303.setPortableYn(StringUtils.isEmpty(info.getPortableYn()) ? null : info.getPortableYn());
	    	ocs0303.setPay(info.getPay());
	    	ocs0303.setPrnYn(StringUtils.isEmpty(info.getPrnYn()) ? null : info.getPrnYn());
	    	ocs0303.setPowderYn(StringUtils.isEmpty(info.getPowderYn()) ? null : info.getPowderYn());
	    	ocs0303.setDv1(CommonUtils.parseDouble(info.getDv1()));
	    	ocs0303.setDv2(CommonUtils.parseDouble(info.getDv2()));
	    	ocs0303.setDv3(CommonUtils.parseDouble(info.getDv3()));
	    	ocs0303.setDv4(CommonUtils.parseDouble(info.getDv4()));
	    	ocs0303.setMixGroup(StringUtils.isEmpty(info.getMixGroup()) ? null : info.getMixGroup());
	    	ocs0303.setOrderRemark(StringUtils.isEmpty(info.getOrderRemark()) ? null : info.getOrderRemark());
	    	ocs0303.setNurseRemark(StringUtils.isEmpty(info.getNurseRemark()) ? null : info.getNurseRemark());
	    	ocs0303.setOrderGubun(StringUtils.isEmpty(info.getOrderGubun()) ? null : info.getOrderGubun());
	    	ocs0303.setWonyoiOrderYn(StringUtils.isEmpty(info.getWonyoiOrderYn()) ? null : info.getWonyoiOrderYn());
	    	ocs0303.setDangilGumsaOrderYn(StringUtils.isEmpty(info.getDangilGumsaOrderYn()) ? null : info.getDangilGumsaOrderYn());
	    	ocs0303.setDangilGumsaResultYn(StringUtils.isEmpty(info.getDangilGumsaResultYn()) ? null : info.getDangilGumsaResultYn());
	    	ocs0303.setInputTab(StringUtils.isEmpty(info.getInputTab()) ? null : info.getInputTab());
	    	ocs0303.setHubalChangeYn(StringUtils.isEmpty(info.getHubalChangeYn()) ? null : info.getHubalChangeYn());
	    	ocs0303.setPharmacy(StringUtils.isEmpty(info.getPharmacy()) ? null : info.getPharmacy());
	    	ocs0303.setJusaSpdGubun(StringUtils.isEmpty(info.getJusaSpdGubun()) ? null : info.getJusaSpdGubun());
	    	ocs0303.setDrgPackYn(StringUtils.isEmpty(info.getDrgPackYn()) ? null : info.getDrgPackYn());
	    	ocs0303.setUpdId(info.getUserId());
	    	ocs0303.setHospCode(hospCode);
	    	ocs0303.setMembGubun(info.getMembGubun());
	    	ocs0303.setHangmogName(StringUtils.isEmpty(info.getHangmogName()) ? null : info.getHangmogName());
	    	ocs0303.setAmt(CommonUtils.parseDouble(info.getAmt()));
	    	ocs0303.setBomSourceKey(CommonUtils.parseDouble(info.getBomSourceKey()));
	    	ocs0303.setNdayYn(StringUtils.isEmpty(info.getNdayYn()) ? null : info.getNdayYn());
	    	ocs0303.setFkocs0300Seq(aPkSeq);
	    	ocs0303Repository.save(ocs0303);
	    }
}