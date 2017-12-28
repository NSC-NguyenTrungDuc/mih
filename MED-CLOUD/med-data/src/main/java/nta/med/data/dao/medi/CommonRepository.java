package nta.med.data.dao.medi;

import java.math.BigInteger;
import java.util.List;

import nta.med.core.domain.BaseEntity;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.common.SequenceInfo;
import nta.med.data.model.ihis.cpls.CPL3020U02GetSpecimenInfoSelectListItemInfo;
import nta.med.data.model.ihis.nuro.NuroChkGetWonyoiYnInfo;

import org.springframework.stereotype.Repository;

/**
 * The Interface CommonRepository.
 */
@Repository
public interface CommonRepository extends org.springframework.data.repository.Repository<BaseEntity, Long> {
 
 /**
  * Gets the next val.
  *
  * @param seqName the seq name
  * @return the next val
  */
 public String getNextVal(String seqName);
 
 public String getNextValByHospCode(String hospCode, String seqName);
 
 public List<CPL3020U02GetSpecimenInfoSelectListItemInfo> getCPL3020U02GetSpecimenInfoSelectListItemInfo(String hospCode, String language, String gwa, String hoDong, String orderDate);
 
 public String getGubunName(String hospCode, String date, String gubun);
 
 public String getGwaNameBAS0260(String hospCode, String language, String gwa, String date);
 
 public NuroChkGetWonyoiYnInfo getNuroChkGetWonyoiYnInfo(String hospCode, String language, String gubun,
   String gongbiCode1, String gongbiCode2, String gongbiCode3, String gongbiCode4);

 public String getFormEnvironInfoSysDate(Integer offset, String format);

// public String getFormEnvironInfoSysDateTime(Integer offset);
 
 public BigInteger getXMstGridDeleteRowInfo(String tableName, String whereCmd, String hospCode, String columnName);
 
 public String callFnLoadOcsCodeName(String hospCode, String mapGubun, String code, String language);
 
 public List<ComboListItemInfo> getIfs003U03GridFindClickListItem(String mapGubun, String hospCode, String find, String language, Integer startNum, Integer endNum);
 
 public List<String> getColumnInformation(String table);
 public String getMessageByCodeAndLanguage(String code, String language);
 
 public SequenceInfo getSeqInfo(String seqName, String hospCode);
 public String getFormEnvironSysDateTimePATTERNHHMM();
 public void truncateTable(String tableName);
 public void deleteTable(String tableName);
 public String checkColumnExistOnTable(String tableName, String tableSchema);
 
//[Start] Med-1.5.2 Basic Design: MED-8065
 public String getNextBunho(String seqName, String seqInc, String hospCode);
 public String getSeqInc(String seqName, String hospCode);
//[End] Med-1.5.2 Basic Design: MED-8065
 
 public String getCurrentSeq(String seqName, String hospCode);
 public Integer updateSequence(String seqName, String hospCode, Integer maxBunho);
 public Double callFnDrgWonyoiTotSurang(Double nalsu, Double suryang, Double dv, String dvTime);
 
 public String getSystemDateTime();
}